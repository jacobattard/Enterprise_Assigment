﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket() {
            //Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        [ForeignKey("Flight")]
        public Guid FlightIdFK { get; set; }
        public string Passport { get; set; }
        public string PassportImagePath { get; set; }
        public double PricePaid { get; set; }
        public bool Cancelled { get; set; }
    }
}
