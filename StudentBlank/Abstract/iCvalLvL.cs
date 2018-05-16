using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iCvalLvL
    {
        ECvalLvL Add(ECvalLvL item);
        IList<ECvalLvL> GetAll();
        void Delete(ECvalLvL item);
        void Save();
        void Dispose();

    }
}
