namespace BikesByBDEGLR.Models
{
    public class BikeStation
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<Bike> Bikes { get; set; }
    }
}
