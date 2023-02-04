using NextLua.Entities.DTOs;

namespace NextLua.UI.Models.HomePage;

public class BoughtCarVM
{
    public List<BoughtCarDto> Cars { get; set; } = new List<BoughtCarDto>();

}