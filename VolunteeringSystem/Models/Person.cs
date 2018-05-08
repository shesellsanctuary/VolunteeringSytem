﻿using System;

namespace VolunteeringSystem.Models
{
    public class Person
    {
        public string name { get; set; }

        public DateTime birthDate { get; set; }

        public string CPF { get; set; }

        public Sex sex { get; }
    }
}