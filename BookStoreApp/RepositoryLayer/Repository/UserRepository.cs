using Microsoft.Extensions.Configuration;
using ModelLayer.Interface;
using ModelLayer.Model;
using MongoDB.Driver;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<RegisterModel> userData;
        private readonly IConfiguration Configuration;

        public UserRepository(IBookStoreDataBaseSetting settings, IConfiguration configuration)
        {
            this.Configuration = configuration;
            var client = new MongoClient(settings.ConnectionString); // connection with DB
            var dataBase = client.GetDatabase(settings.DataBaseName);

            this.userData = dataBase.GetCollection<RegisterModel>("BookUser");
        }

        public async Task<RegisterModel> RegisterUser(RegisterModel user)
        {
            try
            {
                //var CheckEmail = await this.userData.AsQueryable().SingleOrDefaultAsync(a => a.EmailId == user.EmailId);
                //if (CheckEmail != null)
                //{
                    await this.userData.InsertOneAsync(user);

                //    return CheckEmail;
                //}
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
