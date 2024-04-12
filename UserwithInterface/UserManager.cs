using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserwithInterface
{
    public class UserManager : IBaseOperation<User>
    {


        public void AddUser(User user)
        {
            Database<User>.Instance.Users.Add(user);
        }
        public void RemoveUser(int id, out string message)
        {
            var deleteUser = Database<User>.Instance.Users.Find(x => x.Id == id);
            if (deleteUser != null)
            {
                Database<User>.Instance.Users.Remove(deleteUser);
                message = "Basariyla silindi";
            }
            else
                message = "Bele reqem yoxdu";
        }
        public void RemoveUser(string name, out string message)
        {
            var deleteUser = Database<User>.Instance.Users.Find(x => x.Name == name);
            if (deleteUser != null)
            {
                Database<User>.Instance.Users.Remove(deleteUser);
                message = "Basariyla silindi";
            }
            else
                message = "Bele reqem yoxdu";
        }
        public List<User> GetAllUser()
        {
            return Database<User>.Instance.Users;
        }
        public List<User> GetAllUser(User user)
        {
            return Database<User>.Instance.Users.Where(u => u.Name != "admin").ToList();
        }
        public List<User> UpdateUser(User user)
        {
            foreach (var item in Database<User>.Instance.Users)
            {
                if (item.Id == user.Id)
                {
                    item.Name = user.Name;
                    item.SurName = user.SurName;
                    item.Password = user.Password;
                }
            }
            return Database<User>.Instance.Users;
        }

        
    }
}
