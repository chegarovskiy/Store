using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Spare.WebUI.Models
{
    public class PaigingInfo
    {
        // колличество товаров
        public int TotalItems { get; set; }
        // колличество товаров на одной странице
        public int ItemsPerPage { get; set;}
        // номер текущей страници
        public int CurrentPage { get; set; }
        // общее колличество страниц
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
    }
}