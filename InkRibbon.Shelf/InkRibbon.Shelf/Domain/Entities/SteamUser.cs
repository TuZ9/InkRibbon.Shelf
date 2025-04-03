namespace InkRibbon.Shelf.Domain.Entities
{
    public class SteamUser
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
        public required string avatarhash { get; set; }
        public int lastlogoff { get; set; }
        public int personastate { get; set; }
        public required string realname { get; set; }
        public required string primaryclanid { get; set; }
        public int timecreated { get; set; }
        public int personastateflags { get; set; }
        public required string loccountrycode { get; set; }
        public required string locstatecode { get; set; }
        public int loccityid { get; set; }
    }

    public class Response
    {
        public required List<Player> players { get; set; }
    }
}
