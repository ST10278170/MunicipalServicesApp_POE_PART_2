using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class EventItem
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }
    }
}