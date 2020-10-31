using System;
using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.UserData;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Server;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Logic
{
    public class PartyLobby
    {
        public GameBrand Brand;
        public GameMode Mode;
        public List<Player> ConnectedPlayers = new List<Player>();
        public Dictionary<Player, PartyMemberInviteStatus> Invites = new Dictionary<Player, PartyMemberInviteStatus>();

        public PartyLobby(GameBrand brand, GameMode mode, Player creator)
        {
            Brand = brand;
            Mode = mode;
            ConnectedPlayers.Add(creator);
            creator.IsPartyHost = true;
            creator.HasPartyInvitePrivileges = true;
            creator.CurrentPartyLobby = this;

            var response = new CreatePartyLobbyMessage((int)brand);
            creator.Client.SendMessage(response);
            Invites[creator] = PartyMemberInviteStatus.Accepted;
        }

        private static int _globalId = 1;
        private int _id;

        public int Id
        {
            get
            {
                if (_id == 0)
                {
                    _id = _globalId++;
                }

                return _id;
            }
        }

        public void SetGameMode(GameBrand brand, GameMode mode)
        {
            var result = HostSetPartyConfigsMessage.PartyConfigChangeResult.Okay;

            if ((mode.ToString().StartsWith("Coven") ^ brand == GameBrand.Coven)
                || !Enum.GetNames(typeof(GameMode)).Contains(mode.ToString()))
            {
                result = HostSetPartyConfigsMessage.PartyConfigChangeResult.InvalidGameMode;
            }

            if (brand == GameBrand.Coven && ConnectedPlayers.Any(x => !x.Data.UserAccountFlags.OwnsCoven))
            {
                result = HostSetPartyConfigsMessage.PartyConfigChangeResult.SomeoneLacksCoven;
            }

            var message = new HostSetPartyConfigsMessage(brand, mode, result);
            foreach (var player in ConnectedPlayers)
            {
                player.Client.SendMessage(message);
            }

            if (result != HostSetPartyConfigsMessage.PartyConfigChangeResult.Okay)
            {
                return;
            }

            Brand = brand;
            Mode = mode;
        }

        public void LeaveLobby(Player player)
        {
            if (!ConnectedPlayers.Contains(player))
            {
                return;
            }

            var hostExited = GetHost().Equals(player);

            player.CurrentPartyLobby = null;
            player.IsPartyHost = false;
            player.HasPartyInvitePrivileges = false;

            PendingPartyInviteStatusMessage inviteUpdate = null;
            if (Invites.ContainsKey(player))
            {
                Invites[player] = PartyMemberInviteStatus.Left;
                inviteUpdate = new PendingPartyInviteStatusMessage(Invites[player], player.Data.UserName);
            }

            ConnectedPlayers.Remove(player);

            var message = new PartyMemberLeftMessage(player.Data.UserName);
            foreach (var member in ConnectedPlayers)
            {
                member.Client.SendMessage(message);

                if (inviteUpdate != null)
                {
                    member.Client.SendMessage(inviteUpdate);
                }
            }

            player.Client.SendMessage(new LeavePartyMessage());

            if (ConnectedPlayers.Count <= 0)
            {
                lock (Program.PartyLobbiesLock)
                {
                    Program.PartyLobbies.Remove(this);
                }
            }
            else if (hostExited)
            {
                TransferHost(player, ConnectedPlayers[0]);
            }
        }

        public Player GetHost()
        {
            foreach (var player in ConnectedPlayers)
            {
                if (player.IsPartyHost)
                {
                    return player;
                }
            }

            return null;
        }

        public void InviteUser(Player invitor, string invitedUserName)
        {
            if (!invitor.IsPartyHost || !invitor.HasPartyInvitePrivileges)
            {
                return;
            }

            var invitedPlayer = PlayerManager.FindUser(invitedUserName);
            if (invitedPlayer == null)
            {
                return;
            }

            var inviteStatus = PartyMemberInviteStatus.Pending;
            if (invitedPlayer.Client == null || invitedPlayer.Data.UserAccountFlags.IsRestricted)
            {
                inviteStatus = PartyMemberInviteStatus.Failed;
            }

            if (Brand == GameBrand.Coven && !invitedPlayer.Data.UserAccountFlags.OwnsCoven)
            {
                inviteStatus = PartyMemberInviteStatus.NoCoven;
            }

            if (invitor.Data.UserSettings.QueueLanguage != invitedPlayer.Data.UserSettings.QueueLanguage)
            {
                inviteStatus = PartyMemberInviteStatus.Locale;
            }

            Invites[invitedPlayer] = inviteStatus;
            var invite = new PartyInviteNotificationMessage(new PartyInvite(Id, GetHost().Data.UserName));
            invitedPlayer.Client?.SendMessage(invite);

            var inform = new PendingPartyInviteStatusMessage(inviteStatus, invitedPlayer.Data.UserName);
            foreach (var player in ConnectedPlayers)
            {
                player.Client?.SendMessage(inform);
            }
        }

        public void JoinPlayer(Player player)
        {
            var packetsToSendToJoined = new List<BaseMessage>
            {
                new AcceptedPartyInviteMessage(PartyMemberInviteStatus.Accepted),
                new HostSetPartyConfigsMessage(Brand, Mode, HostSetPartyConfigsMessage.PartyConfigChangeResult.Okay),
                new NewPartyHostNotificationMessage(GetHost().Data.UserName)
            };

            foreach (var invite in Invites)
            {
                packetsToSendToJoined.Add(new PendingPartyInviteStatusMessage(invite.Value, invite.Key.Data.UserName));
            }

            player.Client.SendMultipleMessages(packetsToSendToJoined.ToArray());

            ConnectedPlayers.Add(player);
            player.IsPartyHost = false;
            player.HasPartyInvitePrivileges = false;
            player.CurrentPartyLobby = this;
        }

        public void TransferHost(Player currentHost, Player toTransfer)
        {
            currentHost.IsPartyHost = false;
            currentHost.HasPartyInvitePrivileges = false;
            toTransfer.IsPartyHost = true;
            toTransfer.HasPartyInvitePrivileges = true;

            foreach (var member in ConnectedPlayers)
            {
                if (member.Equals(toTransfer))
                {
                    member.Client.SendMessage(new YouArePartyHostMessage());
                }
                else
                {
                    member.Client.SendMessage(new NewPartyHostNotificationMessage(toTransfer.Data.UserName));
                }
            }
        }

        public void GiveInvitePrivileges(Player toGivePrivileges)
        {
            var packet = new PartyInvitePowerNotificationMessage(toGivePrivileges.Data.UserName);

            toGivePrivileges.HasPartyInvitePrivileges = true;

            foreach (var member in ConnectedPlayers)
            {
                member.Client.SendMessage(packet);
            }
        }

        public void KickPlayer(Player toKick)
        {
            Invites[toKick] = PartyMemberInviteStatus.Kicked;
            var packet = new PartyMemberKickedMessage(toKick.Data.UserName);
            var inviteUpdate = new PendingPartyInviteStatusMessage(
                Invites[toKick],
                toKick.Data.UserName
            );

            toKick.CurrentPartyLobby = null;
            toKick.HasPartyInvitePrivileges = false;

            foreach (var member in ConnectedPlayers)
            {
                member.Client.SendMultipleMessages(packet, inviteUpdate);
            }

            ConnectedPlayers.Remove(toKick);
        }

        public void SendChatMessage(Player player, string message)
        {
            // todo *maybe* log chat somewhere?
            var packet = new PartyChatMessage(player.Data.UserName, message);

            foreach (var member in ConnectedPlayers)
            {
                member.Client.SendMessage(packet);
            }
        }
    }
}
