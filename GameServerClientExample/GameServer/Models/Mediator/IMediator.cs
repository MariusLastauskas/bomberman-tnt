using System;
namespace GameServer.Models.Mediator
{
    public interface IMediator
    {
        void SendMessage(string message, PlayerChat player);
    }
}
