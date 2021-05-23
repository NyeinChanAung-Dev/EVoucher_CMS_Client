using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EVoucher_CMS_Client.Models.RequestModels
{
    public class CheckStockAvaliableRequest
    {
        [Required]
        public string VoucherNo { get; set; }
    }
}
