using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
   public  interface iFinImport
    {
        EFinInport Add(EFinInport item);
        IList<EFinInport> GetAll();

        void Delete(EFinInport item);
        void Save();
        void Dispose();
    }
}
