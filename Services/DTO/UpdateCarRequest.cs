namespace AspNetCodeReact.Services.DTO
{
    public readonly record struct UpdateCarRequest(
        int? Id,
        int BrandId,
        int BodyTypeId,
        string Name,
        int SeatsCount,
        string? DealerUrl);
}
