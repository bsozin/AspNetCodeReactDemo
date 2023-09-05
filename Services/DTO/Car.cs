namespace AspNetCodeReact.Services.DTO
{
    public readonly record struct Car(int Id, NamedId Brand, NamedId BodyType, string Name, int SeatsCount, string? DealerUrl);
}
