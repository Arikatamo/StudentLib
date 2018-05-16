using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CStudent : iStudent
    {
        private EFContext _context;
        public CStudent(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public EStudent Add(EStudent item)
        {
          return _context.Student.Add(item);
        }

        public void Delete(EStudent item)
        {
            _context.Student.Remove(item);
        }

        public IList<EStudent> GetAll()
        {
            return _context.Student.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
