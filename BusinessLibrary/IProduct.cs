namespace BusinessLibrary
{
    public interface IProduct
    {
        string ProductDesc { get; set; }
        string ProductId { get; set; }
        string ProductName { get; set; }
        int StockQuantity { get; set; }
    }
}