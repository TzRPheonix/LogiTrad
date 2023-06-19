using SQLite;
namespace ProjetTest.Data;
public class Translation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string OriginLanguage { get; set; }
    public string OriginText { get; set; }
    public string TargetText { get; set; }
    public string TargetLanguage { get; set; }
}