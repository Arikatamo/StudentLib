using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CPassport : iPassport
    {
        private EFContext _context;
        public CPassport(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public Epassport Add(Epassport item)
        {
            return _context.Passport.Add(item);
        }

        public void Delete(Epassport item)
        {
            _context.Passport.Remove(item);
        }

        public IList<Epassport> GetAll()
        {
            return _context.Passport.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
