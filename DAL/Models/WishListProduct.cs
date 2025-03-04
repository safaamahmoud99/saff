﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("WishListProduct")]
    public class WishListProduct
    {      
            public int ID { get; set; }

            [ForeignKey("product")]
            public int productId { get; set; }
            public Product product { get; set; }

            [ForeignKey("Wishlist")]
            public string WishlistID { get; set; }
            public WishList Wishlist { get; set; }
        }
}

