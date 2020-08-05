using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Entities
{
    public class Shipping
    {
        public int ShippingId { get; set; }
        [Required(ErrorMessage = "Kargo adı boş bırakılamaz.")]
        [DisplayName("Kargo Adı")]
        public string ShippingName { get; set; }
        [DisplayName("Kargo Açıklaması")]
        public string ShippingDescription { get; set; }
        [Required(ErrorMessage = "Kargo ücreti boş bırakılamaz.")]
        [DisplayName("Kargo ücreti")]
        public int ShippingFee { get; set; }
    }
}
