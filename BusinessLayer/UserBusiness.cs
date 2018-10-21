using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBusiness
    {
        private UserRepository userRepository;

        public UserBusiness()
        {

            this.userRepository = new UserRepository();

        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();


        }

        public bool GetUser(string username, string password)
        {
            User user = new User();
            List<User> lista = this.userRepository.GetAllUsers().Where(u => u.Username.Equals(username) && u.Password.Equals(password)).ToList();

            if (lista.Count() > 0)
            {
                user = lista.First();
                return true;
            }
            else
            {
                return false;
            }
            

        }

        public bool InsertUser(User u)
        {

            if (userRepository.InsertUser(u) > 0)
            {

                return true;

            }
            else
            {

                return false;

            }

        }












    }
}
