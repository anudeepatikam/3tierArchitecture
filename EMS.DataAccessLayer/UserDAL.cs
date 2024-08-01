using EMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer
{
    public class UserDAL
    {
        private readonly EMSDBContext _context;

        public UserDAL(EMSDBContext eMSDBContext)
        {
            _context = eMSDBContext;
            
        }
        public bool InsertUser(UserMaster user)
        {  
            _context.UserMaster.Add(user);
            _context.SaveChanges();
            return true;   
        }

        public bool EditUser(int Id)
        {
            var user = _context.UserMaster.Find(Id);
            if (user != null)
            {
                _context.SaveChanges(); return true;
            }
            return false;
        }

        public UserMaster GetUserById(int id)
        {
            return _context.UserMaster.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUser(UserMaster userEntity)
        {
            var existingUser = _context.UserMaster.FirstOrDefault(u => u.Id == userEntity.Id);
            if (existingUser != null)
            {
                existingUser.Name = userEntity.Name;
                existingUser.Address = userEntity.Address;
                existingUser.Age = userEntity.Age;
                existingUser.Email = userEntity.Email;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserMaster> GetAllUsers()
        {
            return _context.UserMaster.ToList();
        }

        public bool DeleteUser(int id)
        {
            var user = _context.UserMaster.Find(id);
            if (user != null)
            {
                _context.UserMaster.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<UserMaster> GetUserByIdAsync(int id)
        {
            return await _context.UserMaster.FindAsync(id);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.UserMaster.FindAsync(id);
            if (user == null) return false;

            _context.UserMaster.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
