﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDunia.Domain.Entities
{
    public class DailyDeals
    {
        public int DailyDealId { get; set; }
        public int StoreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
    }

    public class DailyDealsValues
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
