namespace ParkShark.API.Controllers.Divisions
{
    public class DivisionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName{ get; set; }
        public int DirectorId { get; set; }
        public int? ParentDivisionId { get; set; }

    }
}