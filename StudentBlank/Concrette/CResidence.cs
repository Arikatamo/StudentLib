using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CResidence : iResidence
    {
        private EFContext _context;
        public CResidence(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EResidenc Add(EResidenc item)
        {
            return _context.Residence.Add(item);
        }

        public void Delete(EResidenc item)
        {
            _context.Residence.Remove(item);
        }

        public IList<EResidenc> GetAll()
        {
            return _context.Residence.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
