using entities;
using entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public RatingRepository(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;

        }

        public async Task<Rating> addRating(Rating rating)
        {
            await _CookwareShopContext.Ratings.AddAsync(rating);
            await _CookwareShopContext.SaveChangesAsync();
            return rating;
        }
    }
}
