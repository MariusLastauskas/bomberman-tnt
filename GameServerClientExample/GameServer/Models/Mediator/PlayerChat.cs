using System;
namespace GameServer.Models.Mediator
{
    abstract class PlayerChat
    {
        protected IMediator mediator;

        public PlayerChat(IMediator _mediator)
        {
            mediator = _mediator;
        }
    }
}
