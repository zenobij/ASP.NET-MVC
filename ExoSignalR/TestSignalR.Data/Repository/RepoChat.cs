using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSignalR.Data.Models;
using TestSignalR.Data.Repository.Interfaces;

namespace TestSignalR.Data.Repository
{
    public class RepoChat : IChat,IDisposable
    {
        private ChatContext context;

        public RepoChat()
        {
            context = new ChatContext();
        }

        public void Add(Chat c)
        {
            context.Chats.Add(c);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Chats.Remove(context.Chats.FirstOrDefault(m => m.ChatId == id));
            context.SaveChanges();
        }

        public void Dispose()
        {
            context = null;
        }

        public IEnumerable<Chat> GetAll()
        {
            return context.Chats;
        }
    }
}
