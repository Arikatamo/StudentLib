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
    public class Sex: iSex
    {
        private iSex _item;
        private EFContext context;
        public Sex()
        {
            context = new EFContext();
            _item = new CSex(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ESex Add(ESex item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Sex == item.Sex))
            {
                ESex temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ESex item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Sex == item.Sex))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ESex> GetAll()
        {
            IList<ESex> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
