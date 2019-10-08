namespace BusinessLibrary
{
    public interface ICartItem
    {
        IProduct Product { get; set; }
        int ProductQuantinty { get; set; }
    }
}