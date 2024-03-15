using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    internal class Buy<T>
    {
        public List<T> SoldItem { get; set; }
        public int Quantity { get; set; }
        public DateTime SoldTime { get; set; }


    }
}
