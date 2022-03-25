using System.ComponentModel.DataAnnotations;

namespace MicroCloud.Web.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Required]
        [Display(Name = "Kurs süre")]
        public int Duration { get; set; }
    }
}
