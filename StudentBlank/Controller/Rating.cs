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
    public class Rating : iRating
    {
        private iRating _item;
        private EFContext context;
        public Rating()
        {
            context = new EFContext();
            _item = new CRating(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ERating Add(ERating item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Rating == item.Rating))
            {
                ERating temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ERating item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Rating == item.Rating))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ERating> GetAll()
        {
            return _item.GetAll();
        }

        public void Save()
        {
            _item.Save();
        }
    }
}

