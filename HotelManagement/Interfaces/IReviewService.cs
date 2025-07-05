namespace HotelManagement.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Models.Review>> GetAllReviewsAsync();
        Task<Models.Review> GetReviewByIdAsync(int id);
        Task<Models.Review> AddReviewAsync(Models.Review review);
        Task<Models.Review> UpdateReviewAsync(Models.Review review);
        Task DeleteReviewAsync(int id);
    }
}
