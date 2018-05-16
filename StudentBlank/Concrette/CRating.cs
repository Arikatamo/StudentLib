using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CRating: iRating
    {
        private EFContext _context;
        public CRating(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ERating Add(ERating item)
        {
            return _context.Rating.Add(item);
        }

        public void Delete(ERating item)
        {
            _context.Rating.Remove(item);
        }

        public IList<ERating> GetAll()
        {
            return _context.Rating.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
