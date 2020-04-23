using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.ViewModel
{
    public class OrderViewModel
    {

        public int OrderId { get; set; }

        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }

    }
}
