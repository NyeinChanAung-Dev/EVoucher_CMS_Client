using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EVoucher_CMS_Client.Models.RequestModels
{
    public class LoginRequest
    {
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
