using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using testProject.Data.Entities;

namespace testProject.Data.Repository
{
    public class TGUserReposiroty : IDataRepository<TGUser>
    {
        private readonly ApplicationContext _context;

        public TGUserReposiroty(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<TGUser> All()
        {
            return _context.TGUsers.ToList();
        }
        public TGUser Get(long id)
        {
                return _context.TGUsers
                    .FirstOrDefault(e => e.Id == id);
        }

        public TGUser Add(TGUser entity)
        {
                var value = Get(entity.Id);
                if (value == null)
                {
                    var result = _context.TGUsers.Add(entity);
                    _context.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    var result = Get(entity.Id);
                    return result;
                }
        }

        public void Update(TGUser entity)
        {
                _context.TGUsers.Update(entity);
                _context.SaveChanges();
        }

        public void Delete(TGUser entity)
        {
                _context.TGUsers.Remove(entity);
                _context.SaveChanges();
        }
        public TGUser[] Find(Func<TGUser, bool> predicator)
        {
                return _context.TGUsers.Where(predicator).ToArray();
        }
    }
}
