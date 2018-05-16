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
    public class Subject : iSubject
    {
        private iSubject _item;
        private EFContext context;
        public Subject()
        {
            context = new EFContext();
            _item = new CSubject(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public ESubject Add(ESubject item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                ESubject temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(ESubject item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<ESubject> GetAll()
        {
            IList<ESubject> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
