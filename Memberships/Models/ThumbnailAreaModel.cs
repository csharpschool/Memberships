using System.Collections.Generic;

namespace Memberships.Models
{
    public class ThumbnailAreaModel
    {
        public string Title { get; set; }
        public IEnumerable<ThumbnailModel> Thumbnails { get; set; }
    }
}