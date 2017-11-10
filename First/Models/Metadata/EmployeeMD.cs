using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    [MetadataType(typeof(EmployeeMD))]
    public partial class EmployeeMD
    {
        public int EmployeeID { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$")]
        public string LastName { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$")]
        public string FirstName { get; set; }
    }
}