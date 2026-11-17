namespace FitZone.Domain.Models.Entities
{
    public class GymHall
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Название зала (например, "Main Hall", "Crossfit Room")
        public int Capacity { get; set; }     // Общая вместимость
        public string Location { get; set; }    // Расположение/этаж
    }
}