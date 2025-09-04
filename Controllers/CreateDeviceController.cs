using DTO;
using Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace DeviceBack.Controllers
{
    [Route("")]
    [ApiController]
    public class CreateDeviceController(ICreateDevice createDevice) : ControllerBase
    {
        private readonly ICreateDevice _createDevice = createDevice;

        [Route("devices")]
        [HttpPost]
        public IActionResult devicesCreate([FromBody] DeviceInputModel device)
        {
          
               ResponseModel result = _createDevice.CreateDevices(device);
                return StatusCode(result.StatusCode, result);
        
        }
    }
}
