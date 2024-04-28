﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.User
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string? NationalNo { get; set; }
        public UserType UserType { get; set; } = UserType.Client;
    }
}
