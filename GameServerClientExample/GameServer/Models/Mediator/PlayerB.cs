using System;
namespace GameServer.Models.Mediator
{
    public class PlayerB : PlayerChat
    {
        public PlayerB(IMediator _mediator) : base(_mediator)
        {
        }

        public void Send(string message)
        {
            ChatAdd("Player B sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            ChatAdd("Player B gets message: " + message);
        }
    }
}
