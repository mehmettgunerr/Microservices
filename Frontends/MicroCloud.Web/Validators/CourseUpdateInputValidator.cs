using FluentValidation;
using MicroCloud.Web.Models.Catalogs;

namespace MicroCloud.Web.Validators
{
    public class CourseUpdateInputValidator : AbstractValidator<CourseUpdateInput>
    {
        public CourseUpdateInputValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("isim alanı boş olamaz");
            RuleFor(c => c.Description).NotEmpty().WithMessage("açıklama alanı boş olamaz");
            RuleFor(c => c.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("süre alanı boş olamaz");
            RuleFor(c => c.Price).NotEmpty().WithMessage("fiyat alanı boş olamaz").ScalePrecision(2, 6).WithMessage("hatalı format"); //$$$.$$
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("kategori alanı seçiniz");
        }
    }
}
