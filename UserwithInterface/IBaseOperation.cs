using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserwithInterface
{
    public interface IBaseOperation<T> where T : class
    {
        public void AddUser(T user);
        public void RemoveUser(int id, out string message);
        public void RemoveUser(string name, out string message);
        public List<T> GetAllUser();
        public List<T> GetAllUser(T user);

        public List<T> UpdateUser(T user);
    }
}

