using SQLite;

namespace MedicinalPlants.Models
{
    public class Plant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommonNames { get; set; }
        public string ScientificNames { get; set; }
        public string Uses { get; set; }
        public string ImagePath { get; set; }
    }
}
