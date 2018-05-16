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
    public class Ratings : iRatings
    {
        private iRatings _item;
        private EFContext context;
        public Ratings()
        {
            context = new EFContext();
            _item = new CRatings(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ERatings Add(ERatings item)
        {
            if (item != null)
            {
                ERatings temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ERatings item)
        {
            if (item != null)
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ERatings> GetAll()
        {
            IList<ERatings> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
