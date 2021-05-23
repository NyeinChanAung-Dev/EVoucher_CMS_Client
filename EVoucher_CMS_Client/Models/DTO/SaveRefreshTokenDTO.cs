using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.DTO
{
    public class SaveRefreshTokenDTO
    {
        public int ExpiryMinute { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}
