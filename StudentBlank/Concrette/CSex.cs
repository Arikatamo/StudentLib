using StudentBlank.Abstract;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Concrette
{
    public class CSex: iSex
    {
        private EFContext _context;
        public CSex(EFContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ESex Add(ESex item)
        {
            return _context.Sex.Add(item);
        }

        public void Delete(ESex item)
        {
            _context.Sex.Remove(item);
        }

        public IList<ESex> GetAll()
        {
            return _context.Sex.ToList();
        }



        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
