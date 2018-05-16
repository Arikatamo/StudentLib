using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
   public interface iRating
    {
        ERating Add(ERating item);
        IList<ERating> GetAll();

        void Delete(ERating item);
        void Save();
        void Dispose();
    }
}
