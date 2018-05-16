using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CFacultet : iFacultet
    {
        private EFContext _context;
        public CFacultet(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EFacultet Add(EFacultet item)
        {
            return _context.Facultet.Add(item);
        }

        public void Delete(EFacultet item)
        {
            _context.Facultet.Remove(item);
        }

        public IList<EFacultet> GetAll()
        {
            return _context.Facultet.ToList();
        }



        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
