using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testProject.Data.Entities;

namespace testProject.Data.Repository
{
    public class MessageRepository : IDataRepository<Message>
    {
        private readonly ApplicationContext _context;

        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Message Add(Message entity)
        {
            _context.Messages.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Message> All()
        {
            return _context.Messages.ToList();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message[] Find(Func<Message, bool> predicator)
        {
            throw new NotImplementedException();
        }

        public Message Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
