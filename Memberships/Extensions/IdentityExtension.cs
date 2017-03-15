using Memberships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Memberships.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserFirstName(this IIdentity identity)
        {
            var db = ApplicationDbContext.Create();
            var user = db.Users.FirstOrDefault(u => u.UserName.Equals(identity.Name));

            return user != null ? user.FirstName : string.Empty;
        }
        public static async Task GetUsers(this List<UserViewModel> users)
        {
            var db = ApplicationDbContext.Create();
            users.AddRange(await (from u in db.Users
                                  select new UserViewModel
                                  {
                                      Id = u.Id,
                                      Email = u.Email,
                                      FirstName = u.FirstName
                                  }).OrderBy(o => o.Email).ToListAsync());
        }
    }
}