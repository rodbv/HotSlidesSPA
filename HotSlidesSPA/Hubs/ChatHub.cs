using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HotSlidesSPA.Hubs
{
    using HotSlidesSPA.Models;

    [HubName("chathub")]
    public class ChatHub : Hub
    {
        private readonly ChatMonitor _chatMonitor;

        public ChatHub() : this(ChatMonitor.Instance) { }

        public ChatHub(ChatMonitor chatMonitor)
        {
            this._chatMonitor = chatMonitor;
        }

        public ChatInfo GetChatInfo()
        {
            return _chatMonitor.GetChatInfo();
        }

        public void Send(ChatMessage message)
        {
            Clients.All.broadcastMessage(message);
        }
    }
}