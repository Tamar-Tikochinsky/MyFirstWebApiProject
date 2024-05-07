using entities.Models;

namespace Repository
{
    public interface IRatingRepository
    {
        Task<Rating> addRating(Rating rating);
    }
}