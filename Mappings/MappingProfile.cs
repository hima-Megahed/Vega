using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vega.Controllers.Resource;
using Vega.Models;

namespace Vega.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Manufacturer, ManufacturerResource>();
            CreateMap<Feature, KeyValuePairResource>();
        }
    }
}
