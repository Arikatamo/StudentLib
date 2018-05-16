using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iResidence
    {
        EResidenc Add(EResidenc item);
        IList<EResidenc> GetAll();
        void Delete(EResidenc item);
        void Save();
        void Dispose();
    }
}
