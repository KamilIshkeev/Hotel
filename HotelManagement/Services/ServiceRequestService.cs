using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class ServiceRequestService : IServiceRequest
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> GetServiceRequestByIdAsync(int id)
        {
            return await _context.ServiceRequests.FindAsync(id);
        }

        public async Task<ServiceRequest> AddServiceRequestAsync(ServiceRequest ServiceRequest)
        {
            _context.ServiceRequests.Add(ServiceRequest);
            await _context.SaveChangesAsync();
            return ServiceRequest;
        }

        public async Task UpdateServiceRequestAsync(ServiceRequest ServiceRequest)
        {
            _context.Entry(ServiceRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            var ServiceRequest = await _context.ServiceRequests.FindAsync(id);
            if (ServiceRequest != null)
            {
                _context.ServiceRequests.Remove(ServiceRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
