using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class GetPurchaseHistoryResponse
    {
        public int PurchaseHistoryId { get; set; }
        public bool IsUsed { get; set; }
        public string PromoCode { get; set; }
        public string QR_Image_Path { get; set; }
    }
}
