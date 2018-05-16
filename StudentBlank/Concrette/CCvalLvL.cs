using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CCvalLvL : iCvalLvL
    {
        private EFContext _context;
        public CCvalLvL(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ECvalLvL Add(ECvalLvL item)
        {
            return _context.CvalLvL.Add(item);
        }

        public void Delete(ECvalLvL item)
        {
            _context.CvalLvL.Remove(item);
        }

        public IList<ECvalLvL> GetAll()
        {
            return _context.CvalLvL.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
