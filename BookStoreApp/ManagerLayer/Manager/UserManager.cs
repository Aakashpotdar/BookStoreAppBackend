using ManagerLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Manager
{
    public class UserManager:IUserManager
    {
        public readonly IUserRepository repo;

        public UserManager(IUserRepository repository)
        {
            this.repo = repository;
        }

        public async Task<RegisterModel> RegisterUser(RegisterModel User)
        {
            User.Password = EncodePasswordToBase64(User.Password);
            try
            {
                return await this.repo.RegisterUser(User);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData = new byte[password.Length];
                encData = System.Text.Encoding.UTF8.GetBytes(password);
                string encodeData = Convert.ToBase64String(encData);
                return encodeData;
            }
            catch (Exception e)
            {
                throw new Exception("error in Base64string" + e.Message);
            }
        }
    }
}
