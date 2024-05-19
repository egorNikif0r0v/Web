namespace StockExchange.API.Contracts.Request
{
    public record BookRequest(
        string Title,
        string Description,
        decimal Price);
}
