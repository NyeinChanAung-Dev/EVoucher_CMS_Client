﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.DTO
{
    public class TokenGeneratedDTO
    {
        public string AccessToken { get; set; }
        public int TokenExpiresMinute { get; set; }
        public string RefreshToken { get; set; }
        public int RefreshTokenExpiresMinute { get; set; }
        public int UserId { get; set; }//Display Name
        public string ErrorStatus;
    }
}
