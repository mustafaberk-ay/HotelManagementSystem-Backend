﻿using System;
using System.Collections.Generic;

namespace HotelManagementSystem.DataModels.DataModels
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
