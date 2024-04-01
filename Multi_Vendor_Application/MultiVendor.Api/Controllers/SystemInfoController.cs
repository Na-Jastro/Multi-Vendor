using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiVendor.Core.Models;
using MultiVendor.Core.Repositories;

namespace MultiVendor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemInfoController : ControllerBase
    {
        private readonly ISystemInfoRepositories _systemInfo;
        public SystemInfoController(ISystemInfoRepositories systemInfo)
        {
            _systemInfo = systemInfo;
        }
        [HttpGet]
        [ActionName("GetAllSystemInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SystemInfo>>> GetAllSystemInfo()
        {
            try
            {
                var systemInfos = await _systemInfo.GetAllSystemInfoAsync();
                if (systemInfos == null)
                {
                    return NotFound("No System info Available");
                }
                return Ok(systemInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ActionName("GetSystemInfoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SystemInfo>> GetSystemInfoById(Guid id)
        {
            try
            {
                var system = await _systemInfo.GetSystemInfoByIdAysnc(id);
                if (system == null)
                { return NotFound("No System Info Available"); }

                return Ok(system);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost()]
        [ActionName("CreateSystemInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SystemInfo>> CreateSystemInfo(SystemInfo systemInfo)
        {
            try
            {
                await _systemInfo.CreateSystemInfoAsync(systemInfo);

                return Ok(systemInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut()]
        [ActionName("UpdateSystemInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SystemInfo>> UpdateSystemInfo(SystemInfo systemInfo)
        {
            try
            {
                var sytmInfo = await _systemInfo.GetSystemInfoByIdAysnc(systemInfo.Id);
                if (sytmInfo == null)
                {
                    return NotFound("No System Info Data");
                }
                await _systemInfo.UpdateSystemInfoAsync(sytmInfo);

                return Ok(sytmInfo);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteSystemInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<SystemInfo>>> DeleteSystemInfo(Guid id)
        {
            try
            {
                var systemInfo = await _systemInfo.GetSystemInfoByIdAysnc(id);
                if(systemInfo == null)
                {
                    return NotFound("No System Info Data");
                }

                await _systemInfo.DeleteSystemInfoAsync(id);
                return Ok(systemInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
