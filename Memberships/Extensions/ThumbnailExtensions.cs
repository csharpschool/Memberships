using Memberships.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Memberships.Extensions
{
    public static class ThumbnailExtensions
    {
        private static async Task<List<int>> GetSubscriptionIdsAsync(
            string userId = null, ApplicationDbContext db = null)
        {
            try
            {
                if (userId == null) return new List<int>();
                if (db == null) db = ApplicationDbContext.Create();

                return await (
                    from us in db.UserSubscriptions
                    where us.UserId.Equals(userId)
                    select us.SubscriptionId).ToListAsync();
            }
            catch { }

            return new List<int>();
        }
    }
}