using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.RequestModels
{
    public class CheckPromoCodeRequest
    {
        public string PromoCode { get; set; }
        public string Phone { get; set; }
    }
}
