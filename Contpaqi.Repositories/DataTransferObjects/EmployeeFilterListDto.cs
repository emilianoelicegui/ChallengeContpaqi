using Contpaqi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contpaqi.Data.DataTransferObjects
{
    public class EmployeeFilterListDto : _FilterListDto
    {
        public string Name { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public EmployeeStatusEnum Status { get; set; }
    }
}
