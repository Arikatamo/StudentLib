using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
     public class CSubject : iSubject
    {
        private EFContext _context;
        public CSubject(EFContext context)
        {
            _context = context;
        }
        public ESubject Add(ESubject item)
        {
            return _context.Subject.Add(item);
        }

        public void Delete(ESubject item)
        {
            _context.Subject.Remove(item);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<ESubject> GetAll()
        {
            return _context.Subject.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
