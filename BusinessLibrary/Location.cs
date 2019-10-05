using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Location
    {
        public int LocationId { get; }

        Location(int locationId)
        {
            this.LocationId = locationId;
        }
    }
}
