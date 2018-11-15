namespace ParkShark.API.Controllers.Divisions
{
    public class DivisionDto
    {
        public string Name { get; set; }
        public int PersonDirectorId { get; set; }
        public DivisionDto(string name, int directorId)
        {
            Name = name;
            PersonDirectorId = directorId;
        }
    }
}