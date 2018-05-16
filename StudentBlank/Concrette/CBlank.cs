using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CBlank : iBlank
    {
        private EFContext _context;
        public CBlank(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EBlanks Add(EBlanks item)
        {
            return _context.Blanks.Add(item);
        }

        public void Delete(EBlanks item)
        {
            _context.Blanks.Remove(item);
        }

        public IList<EBlanks> GetAll()
        {
            return _context.Blanks.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
