﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class QuoteFilterViewModel
    {
        public List<QuoteHdr> Quotes { get; set; }
        public Dictionary<int, string> Companies { get; set; }
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        public Dictionary<Guid, string> Users { get; set; }
        [Display(Name = "User")]
        public Guid UserId { get; set; }
        public string QuoteRef { get; set; }
    }
}