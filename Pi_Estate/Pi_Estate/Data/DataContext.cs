﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Pi_Estate.Models;

namespace Pi_Estate.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Semt> Semts { get; set; }
        public DbSet<Mahalle> Mahalles { get; set; }
        public DbSet<Durum> Durums { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Ilan> Ilans { get; set; }
        public DbSet<Resim> Resims { get; set; }
    }
}