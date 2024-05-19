namespace StockExchange.API.Contracts.Response
{
    public record BookResponse(
        Guid id,
        string title,
        string description,
        decimal price);
}
