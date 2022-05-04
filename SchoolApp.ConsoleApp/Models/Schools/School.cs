// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;

namespace SchoolApp.ConsoleApp.Models.Schools
{
    internal class School
    {
        public Guid SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolLocation { get; set; }
    }
}