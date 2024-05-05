namespace Networm.Domain.Entities
{
    public class NetwormBookmark
    {
        public int Id { get; set; }
        public int NetwormBookId { get; set; } //klucz obcy
        public string Name { get; set; } = default!;
        public string HttpAdress { get; set; } = default!;
        public string? Description { get; set; }
        public List<string>? Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public NetwormBook? NetwormBook { get; set; }  // właściwości nawigacyjne
    }
}