﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher_CMS_Client.Models.ResponseModels
{
    public class GetEVoucherListingResponse 
    {
        public int id { get; set; }
        public string VoucherNo { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
