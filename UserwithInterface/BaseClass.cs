using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserwithInterface
{
    public class BaseClass
    {
        public int Id { get; set; }

        public BaseClass()
        {
            Id = IncrementId();
        }

        private static int id = 0;
        private int IncrementId()
        {
            return id++;
        }
    }
}
