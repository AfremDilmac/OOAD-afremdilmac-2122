﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Pet
    {
        public string Name { get; set; }

        public static List<Pet> GetAllPets()
        {
            string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        }
    }
}
