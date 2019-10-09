using System;
using System.Collections.Generic;
using System.Text;
using BusinessLibrary;

/// <summary>
/// Cart contains a list named Products containing of ICartItems.
/// ICartItems is an object containing:
///     a Product Object (Product Id, Product Name, Product Desc, Product Stock)
///     Order amount (The amount the customer requested)
///     
/// Cart 
/// </summary>

namespace BusinessLibrary
{
    public class Cart : ICart
    {
        public List<ICartItem> Products { get; set; }
        public ICustomer Owner { get; set; }

        public IUpdateCart UpdateCart { get; }

        public Cart(ICustomer owner)
        {
            Products = Factory.CreateCartItemList();
            this.Owner = owner;
            this.UpdateCart = Factory.CartHandler();
        }

        public void InvetoryItems()
        {
            MessageHandler.ItemsInCart(Products, Owner);
        }

    }
}
