
using System.ComponentModel.DataAnnotations;


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
