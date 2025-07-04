using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IServiceRequest
    {
        Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<ServiceRequest> GetServiceRequestByIdAsync(int id);
        Task<ServiceRequest> AddServiceRequestAsync(ServiceRequest ServiceRequest);
        Task UpdateServiceRequestAsync(ServiceRequest ServiceRequest);
        Task DeleteServiceRequestAsync(int id);
    }
}
