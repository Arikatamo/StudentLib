using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CFinImport : iFinImport
    {
        private EFContext _context;
        public CFinImport(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EFinInport Add(EFinInport item)
        {
            return _context.Finance.Add(item);
        }

        public void Delete(EFinInport item)
        {
            _context.Finance.Remove(item);
        }

        public IList<EFinInport> GetAll()
        {
            return _context.Finance.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

