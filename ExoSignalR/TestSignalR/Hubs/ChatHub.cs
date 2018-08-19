using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TestSignalR.Data.Models;
using TestSignalR.Data.Repository;
using TestSignalR.Data.Repository.Interfaces;

namespace TestSignalR.Hubs
{
    public class ChatHub : Hub
    {

        public void Send(string name, string message)
        {
            using (var repo = new RepoChat())
            {
                repo.Add(new Chat
                {
                    Pseudo = name,
                    Message = message,
                    Date = DateTime.Now,
                    IP = HttpContext.Current.Request.UserHostAddress
                });
            }

            //Permet de joindre une fonction javascript définie
            //dans la page du client
            Clients.All.addNewMessageToPage(name, message);


        }
    }
}