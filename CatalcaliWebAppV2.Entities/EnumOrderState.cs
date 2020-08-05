using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Entities
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor")]
        Bekleyen,
        [Display(Name = "Tamamlandı")]
        Tamamlandı
    }
}
