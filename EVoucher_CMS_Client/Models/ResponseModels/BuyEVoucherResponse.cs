using EVoucher_CMS_Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class BuyEVoucherResponse : ResponseBase
    {
        public string OrderNo { get; set; }
        public bool IsPurchaseSuccess { get; set; }
        public string ErrorResponse { get; set; }

    }
}
