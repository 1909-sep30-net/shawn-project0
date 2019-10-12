using System.Collections.Generic;

namespace Project0.Library
{
    public interface ICustomer
    {
        string CustomerId { get; }
        string NameFirst { get; set; }
        string NameLast { get; set; }
        ICart CustomerCart { get; set; }

    }
}