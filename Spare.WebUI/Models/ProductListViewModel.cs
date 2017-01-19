using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Domain.Entitys;

namespace Spare.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaigingInfo PaigingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}