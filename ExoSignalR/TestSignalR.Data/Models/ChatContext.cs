namespace TestSignalR.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatContext : DbContext
    {
        public ChatContext()
            : base("name=ChatContext")
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
    }
}