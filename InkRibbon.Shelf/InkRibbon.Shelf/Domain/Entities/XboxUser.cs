namespace InkRibbon.Shelf.Domain.Entities
{
    public class XboxUser
    {
        public required Root Root { get; set; }
    }
    
    public class ProfileUser
    {
        public required string id { get; set; }
        public required string hostId { get; set; }
        public List<Setting>? settings { get; set; }
        public bool isSponsoredUser { get; set; }
    }

    public class Root
    {
        public List<ProfileUser>? profileUsers { get; set; }
    }

    public class Setting
    {
        public string? id { get; set; }
        public string? value { get; set; }
    }
}