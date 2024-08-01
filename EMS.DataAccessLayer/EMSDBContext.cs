using EMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer
{
    public class EMSDBContext : DbContext
    {
        public EMSDBContext(DbContextOptions<EMSDBContext> options): base(options)
        {
                
        }

        public DbSet<UserMaster> UserMaster { get; set; }
    }
}
