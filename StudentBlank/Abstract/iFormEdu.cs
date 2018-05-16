using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
   public interface iFormEdu
    {
        EFormEdu Add(EFormEdu item);
        IList<EFormEdu> GetAll();
        void Delete(EFormEdu item);
        void Save();
        void Dispose();
    }
}
