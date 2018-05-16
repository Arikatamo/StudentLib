using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iStudent
    {
        EStudent Add(EStudent item);
        IList<EStudent> GetAll();
        void Delete(EStudent item);
        void Save();
        void Dispose();
    }
}
