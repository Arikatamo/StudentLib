using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iPassport
    {
        Epassport Add(Epassport item);
        IList<Epassport> GetAll();
        void Delete(Epassport item);
        void Save();
        void Dispose();
    }
}
