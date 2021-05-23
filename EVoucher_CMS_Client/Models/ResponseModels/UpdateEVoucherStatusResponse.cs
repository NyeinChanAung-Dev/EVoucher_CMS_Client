using EVoucher_CMS_Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class UpdateEVoucherStatusResponse : ResponseBase
    {
        public bool Updated { get; set; }
        public string VoucherNo { get; set; }
    }
}
