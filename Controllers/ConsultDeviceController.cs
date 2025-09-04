using DTO;
using Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace DeviceBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultDeviceController(IConsultDevice consultDevice) : ControllerBase
    {
        private readonly IConsultDevice _consultDevice = consultDevice;

        [HttpGet("network/{*network}")]
        public IActionResult GetDevicesByNetwork(string network)
        {
            var decodedNetwork = Uri.UnescapeDataString(network);
            ResponseModel result = _consultDevice.FindDevicesNetwork(decodedNetwork);
            return StatusCode(result.StatusCode, result);
        }
    }
}
