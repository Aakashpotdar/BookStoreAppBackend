using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
    public interface IUserManager
    {
        Task<RegisterModel> RegisterUser(RegisterModel User);
    }
}
