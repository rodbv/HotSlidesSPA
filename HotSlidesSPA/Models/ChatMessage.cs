using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotSlidesSPA.Models
{
    public class ChatMessage
    {
        public ChatUser Owner { get; set; }

        public DateTime? Time { get; set; }

        public string Body { get; set; }

      }
}