using System.Collections.Generic;

namespace Project0.Library
{
    public interface IUpdateCart
    {
        void AddItem(List<ICartItem> Products, IProduct product, int quantity);
        void RemoveItem(List<ICartItem> Products, IProduct product, int quantity);
        void RemoveAllItems(List<ICartItem> Products);
    }
}