using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserwithInterface
{
    public class Database<T>
    {
        private static Database<T> _instance;
        public static Database<T> Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new Database<T>();
                return _instance;
            }
        }

        private Database()
        {

        }

        public List<T> Users = new List<T>();
    }
}
