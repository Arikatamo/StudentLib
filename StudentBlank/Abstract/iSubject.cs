using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
   public interface iSubject
    {
        ESubject Add(ESubject item);
        IList<ESubject> GetAll();
        void Delete(ESubject item);
        void Save();
        void Dispose();
    }
}
