using SeniorDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserRepository
    {
        ApplicationDbContext context;
        public UserRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public ApplicationUser GetUser(string username)
        {
            var user = context.Users.Single(x => x.UserName.Equals(username));

            return user;
        }

        public ApplicationUser GetUserById(string id)
        {
            var user = context.Users.Single(x => x.Id.Equals(id));

            return user;
        }
    }
}
