﻿using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resource
{
    public class ContactResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Phone{ get; set; }

        [StringLength(255)]
        public string Email { get; set; }
    }
}