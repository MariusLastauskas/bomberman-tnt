using System;
using System.Collections.Generic;

namespace GameServer.Models.Mediator
{
    public abstract class PlayerChat
    {
        protected IMediator mediator;
        private List<string> chat = new List<string>();

        public PlayerChat(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public List<string> GetChat()
        {
            return chat;
        }
        public void ChatAdd(string line)
        {
            chat.Add(line);
        }
    }
}
