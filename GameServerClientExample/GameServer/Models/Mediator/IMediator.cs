using System;
namespace GameServer.Models.Mediator
{
    interface IMediator
    {
        void SendMessage(string message, PlayerChat player);
    }
}
