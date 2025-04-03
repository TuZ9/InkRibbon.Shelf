namespace InkRibbon.Shelf.Domain.Dto
{
    public class Response
    {
        public List<Player>? players { get; set; }

        public string? steamid { get; set; }

        public int? success { get; set; }
    }
}