using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Controllers.Resource
{
    public class ManufacturerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<KeyValuePairResource> Models { get; set; }

        ManufacturerResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
    }
}
