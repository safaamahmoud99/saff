﻿using BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        int Commit();
        RoleRepository Role { get; }
        CartRepository Cart { get; }
        BrandRepository Brand { get;  }
        ImageRepository Image { get; }
        SupplierRepository Supplier { get;}
        WishListRepository WishList { get; }
        AccountRepository Account { get; }
        OrderRepository Order { get; }
        OfferRepository Offer { get; }
        OrderDetailsRepository Orderdetails { get; }
        CardProductRepository CardProduct { get; }
        WishListProductRepository WishListProduct { get; }
        ReviewRepository Review { get; }
        ProductRepository Product { get; }
        MainCategoryRepository MainCategory { get;}
        CategoryRepository Category { get; }
        SubCategoryRepository SubCategory { get; }
        AdvertisementRepository Advertisement { get; }
    }
}
