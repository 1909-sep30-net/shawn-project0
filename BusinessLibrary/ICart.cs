using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface ICart
    {
        List<IProduct> Products { get; set; }

        void AddItem(IProduct product);
        void RemoveItem(IProduct product);
        List<IProduct> InvetoryItems();
    }
}