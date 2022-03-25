using System.ComponentModel.DataAnnotations;

namespace MicroCloud.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [Required]
        [Display(Name = "Kurs ismi")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Kurs açıklama")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Kurs fiyat")]
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public FeatureViewModel Feature { get; set; }
        [Required]
        [Display(Name = "Kurs kategori")]
        public string CategoryId { get; set; }
    }
}
