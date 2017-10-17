using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Models
{
    interface CRUDInterface<T> where T : class,new()
    {
        IEnumerable<T> Get();
        void Update(T Item);
        void Create(T Item);
        void Delete(T Item);

    }
}
