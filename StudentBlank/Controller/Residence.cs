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
   public class Residence : iResidence
    {
        private iResidence _item;
        private EFContext context;
        public Residence()
        {
            context = new EFContext();
            _item = new CResidence(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public EResidenc Add(EResidenc item)
        {
            if (item != null)
            {
                EResidenc temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception();
            }

        }

        public void Delete(EResidenc item)
        {

            if (item != null)
            {
                _item.Delete(item);
                Save();
            }
               

        }

        public IList<EResidenc> GetAll()
        {
            IList<EResidenc> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }

    }
}
