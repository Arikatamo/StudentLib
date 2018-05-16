using StudentBlank.Abstract;
using StudentBlank.Concrette;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Controller
{
   public class Student : iStudent
    {
        private iStudent _item;
        private EFContext context;
        public Student()
        {
            context = new EFContext();
            _item = new CStudent(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public EStudent Add(EStudent item)
        {
            if (item != _item.GetAll().FirstOrDefault(x =>
            item.Pasport.Serial == item.Pasport.Serial &&
            item.Pasport.Number == item.Pasport.Number))
            {
                EStudent temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Student Alredy Added");
            }
            throw new Exception();
    
        }

        public void Delete(EStudent item)
        {
            if (item == _item.GetAll().FirstOrDefault(x =>
                item.Pasport.Serial == item.Pasport.Serial &&
                item.Pasport.Number == item.Pasport.Number))
            {
                _item.Delete(item);
                _item.Save();
            }
        }

        public IList<EStudent> GetAll()
        {
            IList<EStudent> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
