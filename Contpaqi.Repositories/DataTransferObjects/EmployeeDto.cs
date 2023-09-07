﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contpaqi.Data.DataTransferObjects
{
    public class EmployeeDto
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string CivilStatus { get; set; } = null!;

        public string Rfc { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Position { get; set; } = null!;

        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}