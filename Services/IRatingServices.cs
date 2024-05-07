using entities.Models;

namespace Services
{
    public interface IRatingServices
    {
        Task<Rating> addRating(Rating rating);
    }
}