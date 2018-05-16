using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
   public class CCatZarah : iCatZarah
    {
        private EFContext _context;
        public CCatZarah(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ECatZarah Add(ECatZarah item)
        {
            return _context.CatZarah.Add(item);
        }

        public void Delete(ECatZarah item)
        {
            _context.CatZarah.Remove(item);
        }

        public IList<ECatZarah> GetAll()
        {
            return _context.CatZarah.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
