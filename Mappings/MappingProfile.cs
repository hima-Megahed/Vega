using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vega.Controllers;
using Vega.Controllers.Resource;
using Vega.Core.Models;

namespace Vega.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Photo, PhotoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Manufacturer, ManufacturerResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(svr => svr.Contact, option => 
                    option.MapFrom(v => new ContactResource{Email = v.ContactEmail, Name = v.ContactName, Phone = v.ContactPhone}))
                .ForMember(svr => svr.Features, option => option.MapFrom(v => v.Features.Select(f => f.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Model, option =>
                    option.MapFrom(v => new KeyValuePairResource {Id = v.ModelId, Name = v.Model.Name}))
                .ForMember(vr => vr.Contact, option => 
                    option.MapFrom(v => new ContactResource{Email = v.ContactEmail, Name = v.ContactName, Phone = v.ContactPhone}))
                .ForMember(vr => vr.Manufacturer, option =>
                    option.MapFrom(v => new KeyValuePairResource {Id = v.Model.Manufacturer.Id, Name = v.Model.Manufacturer.Name}))
                .ForMember(vr => vr.Features, option =>
                    option.MapFrom(v => v.Features.Select(f => new KeyValuePairResource {Id = f.FeatureId, Name = f.Feature.Name})));


            // API Resource to Domain
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, option => option.Ignore())
                .ForMember(v => v.ContactName, 
                    option => option.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, 
                    option => option.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail,
                    option => option.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.Features, option => option.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove unselected features
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                    // Update Old Vehicle
                    removedFeatures.ForEach(f => v.Features.Remove(f));

                    // Add new features
                    var addedFeatures = vr.Features.Where(fId => v.Features.All(f => f.FeatureId != fId))
                        .Select(fId => new VehicleFeature {FeatureId = fId, VehicleId = vr.Id}).ToList();
                    // Update Old Vehicle
                    addedFeatures.ForEach(vf => v.Features.Add(vf));

                });
        }
    }
}
