using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Logic.UserData
{
    public class Player
    {
        public INetworkService Client;
        public UserData Data;
        private Timer _afkTimer;
        private DateTime _lastAction;
        public DateTime LastAction
        {
            get { return _lastAction; }
            set
            {
                _lastAction = value;

                if (_afkTimer == null)
                {
                    _afkTimer = new Timer {AutoReset = false, Enabled = true, Interval = 300000}; // 5 mins
                    _afkTimer.Elapsed += delegate
                    {
                        PacketHandler.NotifyAllFriendsOfStatusUpdate(this);
                    };
                }

                _afkTimer.Stop();
                _afkTimer.Start();
            }
        }

        public PartyLobby CurrentPartyLobby;
        public bool IsPartyHost;
        public bool HasPartyInvitePrivileges;

        public PreGameLobby CurrentPreGameLobby;
        public bool IsGameHost;

        public Game CurrentGame;

        public List<Player> FriendList
        {
            get
            {
                var friendIds = Data.FriendIds;
                var ret = new List<Player>();

                lock (Program.PlayersLock)
                {
                    foreach (var friendId in friendIds)
                    {
                        var friend = Program.AllPlayers.FirstOrDefault(x => x.Data.UserId == friendId);
                        if (friend != null)
                        {
                            ret.Add(friend);
                        }
                    }
                }

                return ret;
            }
        }

        public ActivityStatus Status
        {
            get
            {
                if (CurrentGame != null)
                {
                    return ActivityStatus.InGame;
                }

                if (CurrentPartyLobby != null)
                {
                    return ActivityStatus.Active;
                }

                if (CurrentPartyLobby != null)
                {
                    return ActivityStatus.InLobby;
                }

                if (Client == null)
                {
                    return ActivityStatus.Offline;
                }

                if (DateTime.Now - LastAction > TimeSpan.FromMinutes(5))
                {
                    return ActivityStatus.AFK;
                }

                return ActivityStatus.Online;
            }
        }
    }
}
