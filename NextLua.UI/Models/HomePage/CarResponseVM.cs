using NextLua.Entities.DTOs;

namespace NextLua.UI.Models.HomePage;

public class CarResponseVM
{
    public List<CarResponseDto> Cars { get; set; } = new List<CarResponseDto>();
}