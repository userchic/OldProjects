using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class BTreeElem<T>
    {
        public T data;
        public BTreeElem<T> next;
        public BTreeElem<T> prev;
        public BTreeElem()
        {
            data = default(T);
            next = null;
            prev = null;
        }
        public BTreeElem(T d)
        {
            data = d;
            prev = null;
            next = null;
        }
        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }
}
