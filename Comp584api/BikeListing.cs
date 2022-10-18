namespace BikeListApi
{
    public class BikeListing
    {
        public DateTime Date { get; set; }

        public int LowEndPrice { get; set; }

        public int HighEndPrice => 32 + (int)(LowEndPrice / 0.5556);

        public string? Bikes { get; set; }
    }
}