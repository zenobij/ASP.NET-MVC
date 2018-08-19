using System.Collections.Generic;
using TestSignalR.Data.Models;

namespace TestSignalR.Data.Repository.Interfaces
{
    public interface IChat
    {
        IEnumerable<Chat> GetAll();

        void Add(Chat c);

        void Delete(int id);
    }
}
