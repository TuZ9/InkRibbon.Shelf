namespace InkRibbon.Shelf.Domain.Entities
{
    public class User
    {
        public required Guid IdUser { get; set; }
        public required Guid IdUserSteam { get; set; }
        public required Guid IdUserXbox { get; set; }
        public required Guid IdUserPlay { get; set; }
        public required string RealName { get; set; }
        public required string GamerTag { get; set; }
        public string? Avatar { get; set; }
        public string? Avatarmedium { get; set; }
        public string? Avatarfull { get; set; }
        public required string Email { get; set; }
    }
}
