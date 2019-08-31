﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<VehicleFeature> Vehicles { get; set; }

        public Feature()
        {
            Vehicles = new Collection<VehicleFeature>();
        }
    }
}
