﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entitys;
using System.Data.Entity;

namespace Store.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        //public EFDbContext() : base("name=EFDbContext")
        //{           
        //}
        public DbSet <Product> Products {get; set;}
    }
}
