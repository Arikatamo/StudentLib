using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CRatings : iRatings
    {
        private EFContext _context;
        public CRatings(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ERatings Add(ERatings item)
        {
            return _context.Ratings.Add(item);
        }

        public void Delete(ERatings item)
        {
            _context.Ratings.Remove(item);
        }

        public IList<ERatings> GetAll()
        {
            return _context.Ratings.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
