using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iFacultet
    {
        EFacultet Add(EFacultet item);
        IList<EFacultet> GetAll();
        void Delete(EFacultet item);
        void Save();
        void Dispose();
    }
}
