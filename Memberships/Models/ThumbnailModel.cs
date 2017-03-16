namespace Memberships.Models
{
    public class ThumbnailModel
    {
        public int ProductId { get; set; }
        public int SubscriptionId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TagText { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public string ContentTag { get; set; }
    }
}