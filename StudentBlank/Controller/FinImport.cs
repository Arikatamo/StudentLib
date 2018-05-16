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
   public class FinImport: iFinImport
    {
        private iFinImport _item;
        private EFContext context;
        public FinImport()
        {
            context = new EFContext();
            _item = new CFinImport(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public EFinInport Add(EFinInport item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                EFinInport temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(EFinInport item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<EFinInport> GetAll()
        {
            IList<EFinInport> temp = _item.GetAll();
            context.Dispose();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
