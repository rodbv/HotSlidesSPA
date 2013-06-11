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

        static Random rnd = new Random();

        public List<ChatUser> ConnectedUsers = new List<ChatUser>()
                                                   {
                                                       new ChatUser { 
                                                           UserName = "Marcos Augusto", 
                                                           UserNick = "@marcoaugusto",
                                                           Avatar = "avatar1.jpg"
                                                       },
                                                         new ChatUser { 
                                                           UserName = "Julia Amaral", 
                                                           UserNick = "@juliaamaral",
                                                            Avatar = "avatar2.jpg"
                                                       },
                                                         new ChatUser { 
                                                           UserName = "Carlos Burle", 
                                                           UserNick = "@carlosburle",
                                                            Avatar = "avatar3.jpg"
                                                       },
                                                         new ChatUser { 
                                                           UserName = "Rob Machado", 
                                                           UserNick = "@robmachado",
                                                            Avatar = "avatar5.png"
                                                       },
                                                         new ChatUser { 
                                                           UserName = "Ana Cristina", 
                                                           UserNick = "@anacristina",
                                                            Avatar = "avatar8.png"
                                                       },
                                                         new ChatUser { 
                                                           UserName = "Paulo Borges", 
                                                           UserNick = "@pauloborges",
                                                            Avatar = "avatar9.png"
                                                       }
                                                   };
        public List<string> RandomQuestions = new List<string>()
                                                  {
                                                      {
                                                          "Não entendi o último slide professor. Poderia repetir?"
                                                      },
                                                      {
                                                          "Quando teremos avaliação sobre o assunto?"
                                                      },
                                                      {
                                                          "Alguém poderia me explicar após a aula?"
                                                      },
                                                      {
                                                          "Esse conteúdo é muito interessante."
                                                      },
                                                      {
                                                          "O material está disponível para download."
                                                      },
                                                      {
                                                          "Alguém poderia me emprestar o livro sobre a matéria?"
                                                      },
                                                      {
                                                          "Que tal formarmos um grupo de estudo?"
                                                      },
                                                      {
                                                          "Vou acompanhar a aula de casa hoje."
                                                      },
                                                      {
                                                          "{NickName} podemos fazer esse trabalho juntos?"
                                                      },
                                                      {
                                                          "Eu diria que o {NickName} é quem mais sabe sobre esse assunto"
                                                      },
                                                      {
                                                          "{NickName} você não fez um trabalho parecido semestre passado?"
                                                      },
                                                      {
                                                          "Professor, qual a data de entrega do resumo dessa apresentação?"
                                                      }
                                                  };

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

        internal ChatMessage GenerateMessage()
        {
            var randomIndexUser = rnd.Next(ConnectedUsers.Count);
            var randomIndexQuestion = rnd.Next(RandomQuestions.Count);
            var randomUser = ConnectedUsers.Where(f => f.UserNick != this.ConnectedUsers[randomIndexUser].UserNick).First();


            return new ChatMessage()
                       {
                           Time = DateTime.Now,
                           Owner = this.ConnectedUsers[randomIndexUser],
                           Body = this.RandomQuestions[randomIndexQuestion].Replace("{NickName}", randomUser.UserNick)
                       };
        }
    }
}