using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface IUpdateCart
    {
        void AddItem(List<ICartItem> Products, IProduct product, int quantity);
        void RemoveItem(List<ICartItem> Products, IProduct product, int quantity);
    }
}