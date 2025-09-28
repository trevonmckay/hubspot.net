using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot.NET.Requests
{
    public record GetPropertiesRequestParameters
    {
        public bool? Archived { get; set; }

        public string? Properties { get; set; }
    }
}
