namespace MedicinalPlants.DTOs
{
    public class PlantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommonNames { get; set; }
        public string ScientificNames { get; set; }
        public string Uses { get; set; }
        public ImageSource ImageSource { get; set; }
    }
}
