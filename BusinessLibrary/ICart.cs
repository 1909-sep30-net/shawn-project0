using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface ICart
    {
        List<ICartItem> Products { get; set; }
        ICustomer Owner { get; set; }

        void AddItem(IProduct product, int quantity);
        void RemoveItem(IProduct product, int quantity);
        void InvetoryItems();
    }
}