using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iCatZarah
    {
        ECatZarah Add(ECatZarah item);
        IList<ECatZarah> GetAll();
        void Delete(ECatZarah item);
        void Save();
        void Dispose();
    }
}
