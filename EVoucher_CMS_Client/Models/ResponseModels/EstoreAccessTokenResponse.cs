using EVoucher_CMS_Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class EstoreAccessTokenResponse : ResponseBase
    {
        public string AccessToken { get; set; }
        public int AccessTokenExpireMinutes { get; set; }
        public string RefreshToken { get; set; }
        public int RefreshTokenExpireMinutes { get; set; }
    }
}
