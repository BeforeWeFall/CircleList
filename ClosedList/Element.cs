using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedList
{
    class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Prev { get; set; }
        public Element<T> Next { get; set; }

        public Element(T data)
        {
            Data = data;
        }
    }
}
