// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;

namespace SchoolApp.ConsoleApp.Models.Schools
{
    internal class School
    {
        public string SchoolName { get; set; }
        public string SchoolDescription { get; set; }
        public Guid SchoolId { get; set; }
        public string SchoolLocation { get; set; }
        public string CountyName { get; set; }
    }
}
