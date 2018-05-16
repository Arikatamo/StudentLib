using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iRatings
    {
        ERatings Add(ERatings item);
        IList<ERatings> GetAll();

        void Delete(ERatings item);
        void Save();
        void Dispose();
    }
}
