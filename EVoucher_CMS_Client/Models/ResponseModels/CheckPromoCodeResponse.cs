using EVoucher_CMS_Client.Models.DTO;
using EVoucher_CMS_Client.Models.Enum;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class CheckPromoCodeResponse : ResponseBase
    {
        public PromoCodeStatus Status { get; set; }
        public decimal PromoAmount { get; set; }
    }
}
