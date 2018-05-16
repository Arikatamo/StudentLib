using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iBlank
    {
        EBlanks Add(EBlanks item);
        IList<EBlanks> GetAll();
        void Delete(EBlanks item);
        void Save();
        void Dispose();
    }
}
