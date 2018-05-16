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
    public class CatZaraH : iCatZarah
    {
        private iCatZarah _item;
        private EFContext context;
        public CatZaraH()
        {
            context = new EFContext();
            _item = new CCatZarah(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ECatZarah Add(ECatZarah item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                ECatZarah temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ECatZarah item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ECatZarah> GetAll()
        {
            IList<ECatZarah> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
