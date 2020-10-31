using System;
using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.Constants;
using TownOfSalem_Logic.Enums;
using TownOfSalem_Logic.UserData;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Server;

namespace TownOfSalem_Logic
{
    public class PreGameLobby
    {
        public List<Player> ConnectedPlayers = new List<Player>(15);
        public GameMode GameMode;
        public Role[] CurrentRoleList;
        public Role[] FullRoleList;
        public bool IsCustomGame;
        public bool AllowCovenRoles;

        public PreGameLobby(GameMode gameMode)
        {
            GameMode = gameMode;

            switch (GameMode)
            {
                case GameMode.Classic:
                    FullRoleList = ConstantRoleLists.ClassicMode.ToArray();
                    break;
                case GameMode.Custom:
                    IsCustomGame = true;
                    break;
                case GameMode.AllAny:
                    FullRoleList = ConstantRoleLists.AllAny.ToArray();
                    break;
                case GameMode.RapidMode:
                    IsCustomGame = true;
                    break;
                case GameMode.Rainbow:
                    FullRoleList = ConstantRoleLists.Rainbow.ToArray();
                    break;
                case GameMode.RankedPractice:
                    FullRoleList = ConstantRoleLists.Ranked.ToArray();
                    break;
                case GameMode.CovenCustom:
                    IsCustomGame = true;
                    AllowCovenRoles = true;
                    break;
                case GameMode.CovenClassic:
                    FullRoleList = ConstantRoleLists.CovenClassic.ToArray();
                    break;
                case GameMode.CovenRankedPractice:
                    FullRoleList = ConstantRoleLists.CovenRanked.ToArray();
                    break;
                case GameMode.CovenAllAny:
                    FullRoleList = ConstantRoleLists.CovenAllAny.ToArray();
                    break;
                case GameMode.CovenVIP:
                    FullRoleList = ConstantRoleLists.CovenVIP.ToArray();
                    break;
                case GameMode.CovenMafiaReturns:
                    FullRoleList = ConstantRoleLists.CovenMafiaReturns.ToArray();
                    break;
                case GameMode.DraculasPalace:
                    FullRoleList = ConstantRoleLists.DraculasPalace.ToArray();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void JoinPlayer(Player newMember)
        {
            ConnectedPlayers.Add(newMember);
            newMember.CurrentPreGameLobby = this;

            var toOtherMembers = new UserJoinedGameMessage(
                GetHost().Equals(newMember),
                false,
                newMember.Data.UserName,
                ConnectedPlayers.Count,
                newMember.Data.UserSelections.LobbyIcon
            );

            foreach (var member in ConnectedPlayers)
            {
                if (member.Equals(newMember))
                {
                    continue;
                }

                member.Client.SendMessage(toOtherMembers);
            }

            var toSendToNew = new List<BaseMessage>
            {
                new CreateLobbyMessage(GetHost().Equals(newMember), (int)GameMode)
            };

            var i = 0;
            foreach (var member in ConnectedPlayers)
            {
                // todo fix lobby icon and chat text not shown
                toSendToNew.Add(new UserJoinedGameMessage(
                    GetHost().Equals(newMember),
                    member.Equals(newMember),
                    member.Data.UserName,
                    i++,
                    member.Data.UserSelections.LobbyIcon
                ));
            }

            int playerCount, gameCount;
            lock (Program.PlayersLock)
            {
                playerCount = Program.AllPlayers.Count(x => x.Client != null);
            }

            lock (Program.GamesLock)
            {
                gameCount = Program.Games.Count;
            }

            toSendToNew.Add(new HowManyPlayersAndGamesMessage(playerCount, gameCount));
            newMember.Client.SendMultipleMessages(toSendToNew.ToArray());

            AutoUpdateRoleList();
        }

        public void LeavePlayer(Player player)
        {
            var returnHome = new ReturnToHomeMessage();
            player.Client.SendMessage(returnHome);

            player.CurrentPreGameLobby = null;

            var leave = new UserLeftGameMessage(true, true, ConnectedPlayers.IndexOf(player));
            ConnectedPlayers.Remove(player);

            if (player.IsGameHost)
            {
                player.IsGameHost = false;
                var newHost = GetHost();
                // todo update host
            }

            foreach (var member in ConnectedPlayers)
            {
                member.Client.SendMessage(leave);
            }

            if (!ConnectedPlayers.Any())
            {
                lock (Program.PreGameLobbiesLock)
                {
                    Program.PreGameLobbies.Remove(this);
                }
            }
        }

        public Player GetHost()
        {
            if (!ConnectedPlayers.Any())
            {
                return null;
            }

            var host = ConnectedPlayers.FirstOrDefault(x => x.IsGameHost);
            if (host != null)
            {
                return host;
            }

            host = ConnectedPlayers[Utility.Random.Next(0, ConnectedPlayers.Count)];
            host.IsGameHost = true;
            return host;
        }

        public void AutoUpdateRoleList()
        {
            if (IsCustomGame)
            {
                return;
            }

            CurrentRoleList = new Role[ConnectedPlayers.Count];
            for (var i = 0; i < ConnectedPlayers.Count; i++)
            {
                CurrentRoleList[i] = FullRoleList[i];
            }

            if (CurrentRoleList.Length >= 15)
            {
                Start();
            }
        }

        public void Start()
        {

        }
    }
}
