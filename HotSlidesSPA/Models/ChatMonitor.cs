using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HotSlidesSPA.Models
{
    using HotSlidesSPA.Hubs;

    public class ChatMonitor
    {
        private readonly static Lazy<ChatMonitor> _instance = new Lazy<ChatMonitor>(() =>
            new ChatMonitor(GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients));

        private ChatMonitor(IHubConnectionContext clients)
        {
            Clients = clients;
        }

        public static ChatMonitor Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext Clients { get; set; }

        public ChatInfo GetChatInfo()
        {
            return new ChatInfo();
        }
    }
}