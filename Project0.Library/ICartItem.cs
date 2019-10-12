namespace Project0.Library
{
    public interface ICartItem
    {
        IProduct Product { get; set; }
        int ProductQuantinty { get; set; }
    }
}