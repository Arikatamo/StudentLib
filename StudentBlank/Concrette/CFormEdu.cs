using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CFormEdu : iFormEdu
    {
        private EFContext _context;
        public CFormEdu(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EFormEdu Add(EFormEdu item)
        {
            return _context.FormEdu.Add(item);
        }

        public void Delete(EFormEdu item)
        {
            _context.FormEdu.Remove(item);
        }

        public IList<EFormEdu> GetAll()
        {
            return _context.FormEdu.ToList();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
