using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Location
    {
        public int LocationId { get; }

        public List<ICartItem> Products { get; set; }

        Location(int locationId)
        {
            this.LocationId = locationId;

        }
    }
}
