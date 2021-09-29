using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessContract
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DataBaseContext _context;

        public TypeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Entities.Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var type = _context.Types.FirstOrDefault(x => x.Id == id);
            _context.Types.Remove(type);
            _context.SaveChanges();
        }

        public List<Entities.Type> GetAll()
        {
            return _context.Types.ToList();
        }

        public Entities.Type GetById(int id)
        {
            return _context.Types.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Entities.Type type)
        {
            _context.Types.Update(type);
            _context.SaveChanges();
        }
    }
}
