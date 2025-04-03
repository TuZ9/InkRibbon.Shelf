

namespace InkRibbon.Shelf.Domain.Dto
{
    public class SteamUserDto
    {
        public required Response response { get; set; }
    }

    public class Player
    {
        public required string steamid { get; set; }
        public int communityvisibilitystate { get; set; }
        public int profilestate { get; set; }
        public required string personaname { get; set; }
        public required string profileurl { get; set; }
        public required string avatar { get; set; }
        public required string avatarmedium { get; set; }
        public required string avatarfull { get; set; }
        public string? avatarhash { get; set; }
        public int lastlogoff { get; set; }
        public int personastate { get; set; }
        public string? realname { get; set; }
        public string? primaryclanid { get; set; }
        public int timecreated { get; set; }
        public int personastateflags { get; set; }
        public string? loccountrycode { get; set; }
        public string? locstatecode { get; set; }
        public int loccityid { get; set; }
    }
}
