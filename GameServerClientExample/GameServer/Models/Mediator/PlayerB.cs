using System;
namespace GameServer.Models.Mediator
{
    class PlayerB : PlayerChat
    {
        public PlayerB(IMediator _mediator) : base(_mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("Player B sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Player B gets message: " + message);
        }
    }
}
