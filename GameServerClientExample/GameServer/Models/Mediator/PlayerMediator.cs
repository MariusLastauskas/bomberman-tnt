﻿using System;
namespace GameServer.Models.Mediator
{
    public class PlayerMediator : IMediator
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
        /*
         * Kažkurioje projekto dalyje turėtų būti implementuota tai:
         * PlayerMediator mediator = new Player mediator();
         * PlayerA playera = new PlayerA(mediator)
         * playerB playerb = new PlayerB(mediator)
         * mediator.PlayerA = playerA;
         * mediator.PlayerB = playerB;
         *
         * playerA.Send("kazkoks pranesimas");
         * playerB.Send("atsako i pranesima");
         */
    }
}
