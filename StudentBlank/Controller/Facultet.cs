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
    public class Facultet : iFacultet
    {
        private iFacultet _item;
        private EFContext context;
        public Facultet()
        {
            context = new EFContext();
            _item = new CFacultet(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public EFacultet Add(EFacultet item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                EFacultet temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(EFacultet item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
                context.Dispose();
            }
        }

        public IList<EFacultet> GetAll()
        {
            IList<EFacultet> temp = _item.GetAll();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
