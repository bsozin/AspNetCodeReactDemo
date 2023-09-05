using FluentValidation;

namespace AspNetCodeReact.Services.Validators
{
    public sealed class UpdateCarRequestValidator : AbstractValidator<DTO.UpdateCarRequest>
    {
        public UpdateCarRequestValidator()
        {
            RuleFor(model => model.BodyTypeId).NotEmpty();
            RuleFor(model => model.BrandId).NotEmpty();
            RuleFor(model => model.DealerUrl).Matches(@"(http:\/\/|https:\/\/)?[\w\-\.]*ru(\/[\w\-\.]*)*").When(model => !string.IsNullOrEmpty(model.DealerUrl));
            RuleFor(model => model.Name).NotEmpty().MaximumLength(1000);
            RuleFor(model => model.SeatsCount).InclusiveBetween(1, 12);
        }
    }
}
