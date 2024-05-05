namespace Networm.Domain.Entities
{
    public class NetwormBook
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string EncodedTitle { get; private set; } = default!;
        public List<NetwormBookmark> Bookmarks { get; set; } = new List<NetwormBookmark>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public void EncodeTitle() => EncodedTitle = Title.ToLower().Replace(" ", "-");
    }
}