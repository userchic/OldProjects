using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TwoSideLinkedPoint<T>
    {
        public T data;
        public TwoSideLinkedPoint<T> next;
        public TwoSideLinkedPoint<T> prev;
        public TwoSideLinkedPoint()
        {
            data = default(T);
            next = null;
            prev = null;
        }
        public TwoSideLinkedPoint(T d)
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
