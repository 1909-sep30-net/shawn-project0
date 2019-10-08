using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface ICart
    {
        List<ICartItem> Products { get; set; }
        ICustomer Owner { get; set; }
        void InvetoryItems();

        UpdateCart UpdateCart { get; }
    }
}