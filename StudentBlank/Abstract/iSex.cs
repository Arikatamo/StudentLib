using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Abstract
{
    public interface iSex
    {
        ESex Add(ESex item);
        IList<ESex> GetAll();
        void Delete(ESex item);
        void Save();
        void Dispose();
    }
}
