using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities.Models;
using Repository;

namespace Services
{
    public class RatingServices : IRatingServices
    {
        IRatingRepository ratingRepository;
        public RatingServices(IRatingRepository _ratingRepository)
        {

            ratingRepository = _ratingRepository;

        }

        public async Task<Rating> addRating(Rating rating)
        {
            Rating resRating = await ratingRepository.addRating(rating);
            return resRating;
        }
    }
}
