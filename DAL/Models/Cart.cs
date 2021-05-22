﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        public ICollection<CartProduct> cartProducts { get; set; }
    }
}
