﻿namespace Rent_A_Car_Web.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public int Seat { get; set; }
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public bool Availabilyty { get; set; }=true;


    }
}
