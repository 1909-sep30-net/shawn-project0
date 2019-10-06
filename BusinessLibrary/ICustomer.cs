﻿using System.Collections.Generic;

namespace BusinessLibrary
{
    public interface ICustomer
    {
        string CustomerId { get; }
        string NameFirst { get; set; }
        string NameLast { get; set; }
        Cart CustomerCart { get; set; }

    }
}