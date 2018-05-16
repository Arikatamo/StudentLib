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
    public class FormEdu: iFormEdu
    {
        private iFormEdu _item;
        private EFContext context;
        public FormEdu()
        {
            context = new EFContext();
            _item = new CFormEdu(context);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public EFormEdu Add(EFormEdu item)
        {
            if (item != _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                EFormEdu temp = _item.Add(item);
                Save();
                return temp;
            }
            else
            {
                throw new Exception("This Subject Alredy Added");
            }


        }

        public void Delete(EFormEdu item)
        {
            if (item == _item.GetAll().FirstOrDefault(x => item.Name == item.Name))
            {
                _item.Delete(item);
                Save();
            }
        }

        public IList<EFormEdu> GetAll()
        {
            IList<EFormEdu> temp = _item.GetAll();
            context.Dispose();
            return temp;
        }

        public void Save()
        {
            _item.Save();
        }
    }
}
