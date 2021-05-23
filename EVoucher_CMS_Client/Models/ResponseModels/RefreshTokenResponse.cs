using EVoucher_CMS_Client.Models.DTO;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class RefreshTokenResponse : ResponseBase
    {
        public string AccessToken { get; set; }
        public int AccessTokenExpireMinutes { get; set; }
        public string RefreshToken { get; set; }
        public int RefreshTokenExpireMinutes { get; set; }
    }
}
