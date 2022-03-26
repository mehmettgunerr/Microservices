using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MicroCloud.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
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
        [Display(Name = "Kurs resmi")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
