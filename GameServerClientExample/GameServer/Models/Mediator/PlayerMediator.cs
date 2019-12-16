using System;
namespace GameServer.Models.Mediator
{
    class PlayerMediator : IMediator
    {
        private PlayerA _playerA;
        private PlayerB _playerB;

        public PlayerA playerA
        {
            set { _playerA = value; }
        }

        public PlayerB playerb
        {
            set { _playerB = value; }
        }

        public void SendMessage(string message, PlayerChat player)
        {
            if (player == _playerA)
            {
                _playerB.Notify(message);
            }
            else
            {
                _playerA.Notify(message);
            }
        }
    }
}
