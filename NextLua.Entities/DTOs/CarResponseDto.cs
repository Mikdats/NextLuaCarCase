using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextLua.Core.Entities;

namespace NextLua.Entities.DTOs
{
    public class CarResponseDto :IDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
