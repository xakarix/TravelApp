using SQLite;

namespace TravelApp;

[Table("InfoData")]

public class InfoData
{
    [PrimaryKey, AutoIncrement, Column("Id")]
    public int Id { get; set; }
    public string Country { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LabelText { get; set; }
}
    
