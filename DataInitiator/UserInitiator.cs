using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FakeBilibili.Data;
using FakeBilibili.Migrations.UserAndVideoDb;
using FakeBilibili.Models;

namespace FakeBilibili.DataInitiator
{
    public class UserInitiator
    {
        private UserAndVideoDbContext _context;

        User[] users=new []
        {
            new User()
            {              
                 
            }, 
            new User()
            {

            }, 
            new User()
            {

            }, 
            new User()
            {

            }, 
            new User()
            {

            }, 
        };

        public UserInitiator(UserAndVideoDbContext context)
        {
            _context = context;
        }

        public static void InitialDataBase()
        {

        }
    }
}
