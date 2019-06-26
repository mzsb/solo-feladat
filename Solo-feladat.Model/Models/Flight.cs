﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Solo_feladat.Model.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime Date { get; set; }
        public FlightStatus Status { get; set; }

        public ICollection<AirportFlight> AirportFlights { get; set; } = new List<AirportFlight>();

        public ICollection<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    }
}
