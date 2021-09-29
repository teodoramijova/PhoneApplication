using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessContract
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly DataBaseContext _context;

        public PhoneRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
             var phone = _context.Phones.FirstOrDefault(x => x.Id == id);
            _context.Phones.Remove(phone);
            _context.SaveChanges();
        }

        public List<Phone> GetAll()
        {
            return _context.Phones.Include(x => x.Category).Include(x => x.Type).ToList();
        }

        public Phone GetById(int id)
        {
            return _context.Phones.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Phone phone)
        {
            var result = _context.Phones.FirstOrDefault(x => x.Id == phone.Id);
            _context.Phones.Update(result);
            _context.SaveChanges();
        }
    }
}
