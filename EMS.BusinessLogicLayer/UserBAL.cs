using EMS.DataAccessLayer;
using EMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessLogicLayer
{

    public class UserBAL
    {
        private readonly UserDAL userDAL;
        public UserBAL(EMSDBContext EMSDBContext)
        {
         userDAL = new UserDAL(EMSDBContext);
        }
        public bool InsertUser(UserMaster userEntity)
        {
            if (userEntity != null)
            {
                 return userDAL.InsertUser(userEntity);
            }
            return false;
        }
        public UserMaster GetUserById(int id)
        {
            return userDAL.GetUserById(id);
        }

        public bool UpdateUser(UserMaster userEntity)
        {
            if (userEntity != null)
            {
                return userDAL.UpdateUser(userEntity);
            }
            return false;
        }
        public List<UserMaster> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }


        public bool DeleteUser(int id)
        {
            return userDAL.DeleteUser(id);
        }
        public async Task<UserMaster> GetUserByIdAsync(int id)
        {
            return await userDAL.GetUserByIdAsync(id);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userDAL.DeleteUserAsync(id);
        }


    }
}
