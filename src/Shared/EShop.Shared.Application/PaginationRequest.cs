namespace EShop.Shared.Application;

public record PaginationRequest(int PageIndex = 0, int PageSize = 10);
