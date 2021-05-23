﻿
using System.ComponentModel.DataAnnotations;

namespace EVoucher_CMS_Client.Models.RequestModels
{
    public class CheckOutEvoucherRequest
    {
        [Required]
        public string Voucher_No { get; set; }
        [Required]
        [MaxLength(300)]
        public string Buyer_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Buyer_Phone { get; set; }
        [Required]
        public string Buy_Type { get; set; }
        [Required]
        public string Payment_Method { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
