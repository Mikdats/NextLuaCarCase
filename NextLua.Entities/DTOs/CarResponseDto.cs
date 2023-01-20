using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextLua.Entities.DTOs
{
    public class CarResponseDto
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }

    }
}
