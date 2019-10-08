using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface ICart
    {
        List<ICartItem> Products { get; set; }

        void AddItem(IProduct product, int quantity);
        void RemoveItem(IProduct product, int quantity);
        List<ICartItem> InvetoryItems();
    }
}