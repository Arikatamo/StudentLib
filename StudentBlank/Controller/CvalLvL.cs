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
    public class CvalLvL: iCvalLvL
    {
        private iCvalLvL _item;
        private EFContext context;
        public CvalLvL()
        {
            context = new EFContext();
            _item = new CCvalLvL(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ECvalLvL Add(ECvalLvL item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                ECvalLvL temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ECvalLvL item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ECvalLvL> GetAll()
        {
            IList<ECvalLvL> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
