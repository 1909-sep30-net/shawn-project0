using System.Collections.Generic;

namespace Project0.Library
{
    public interface ICart
    {
        List<ICartItem> Products { get; set; }
        ICustomer Owner { get; set; }
        void InvetoryItems();

        IUpdateCart UpdateCart { get; }
    }
}