using StudentBlank.Abstract;
using StudentBlank.Concrette;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Controller
{
    public class Passport : iPassport
    {
        private iPassport _item;
        private EFContext context;
        public Passport()
        {
            context = new EFContext();
            _item = new CPassport(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public Epassport Add(Epassport item)
        {
            if (item != _item.GetAll().FirstOrDefault(x =>
            item.Serial == item.Serial &&
            item.Number == item.Number))
            {
                Epassport temp = _item.Add(item);
                Save();
                 return temp;
            }
            else
            {
                throw new Exception("This Student Alredy Added");
            }


        }

        public void Delete(Epassport item)
        {
            if (item == _item.GetAll().FirstOrDefault(x =>
                item.Serial == item.Serial &&
                item.Number == item.Number))
            {
                _item.Delete(item);
                _item.Save();
            }
        }

        public IList<Epassport> GetAll()
        {
            IList<Epassport> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
