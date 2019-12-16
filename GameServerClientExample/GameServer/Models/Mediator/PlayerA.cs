using System;
namespace GameServer.Models.Mediator
{
    class PlayerA : PlayerChat
    {       
        public PlayerA(IMediator _mediator) : base(_mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("Player A sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Player A gets message: " + message);
        }
    }
}
