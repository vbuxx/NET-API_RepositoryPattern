using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels.Region
{
    public class _Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        public List<_Region> Regions = new List<_Region>();

    }
}
