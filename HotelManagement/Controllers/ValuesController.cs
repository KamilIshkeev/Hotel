using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequest _ServiceRequestService;

        public ServiceRequestsController(IServiceRequest ServiceRequestService)
        {
            _ServiceRequestService = ServiceRequestService;
        }

        // GET: api/ServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetAllServiceRequests()
        {
            var ServiceRequests = await _ServiceRequestService.GetAllServiceRequestsAsync();
            return Ok(ServiceRequests);
        }

        // GET: api/ServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
            var ServiceRequest = await _ServiceRequestService.GetServiceRequestByIdAsync(id);

            if (ServiceRequest == null)
            {
                return NotFound();
            }

            return Ok(ServiceRequest);
        }

        // POST: api/ServiceRequests
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(ServiceRequest ServiceRequest)
        {
            var createdServiceRequest = await _ServiceRequestService.AddServiceRequestAsync(ServiceRequest);
            return CreatedAtAction(nameof(GetServiceRequest), new { id = createdServiceRequest.Id }, createdServiceRequest);
        }

        // PUT: api/ServiceRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceRequest(int id, ServiceRequest ServiceRequest)
        {
            if (id != ServiceRequest.Id)
            {
                return BadRequest();
            }

            await _ServiceRequestService.UpdateServiceRequestAsync(ServiceRequest);
            return NoContent();
        }

        // DELETE: api/ServiceRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            await _ServiceRequestService.DeleteServiceRequestAsync(id);
            return NoContent();
        }
    }
}
