using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDASPNETMVCWithEntityFramework.Models
{
    public class clsEmpolyee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PinCode is required.")]
        public Nullable<int> PinCode { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}