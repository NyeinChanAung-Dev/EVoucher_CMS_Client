using EVoucher_CMS_Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class CheckStockAvaliableResponse :ResponseBase
    {
        public bool isAvaliable { get; set; }
        public int RemainingQuantity { get; set; }
    }
}
