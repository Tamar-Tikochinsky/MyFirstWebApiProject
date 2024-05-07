using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderPostDTO
    {
        public DateTime? OrderDate { get; set; }
        public decimal? OrderSum { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<OrderItemProdIdDTO> OrderItems { get; set; } = new List<OrderItemProdIdDTO>();
    }
}
