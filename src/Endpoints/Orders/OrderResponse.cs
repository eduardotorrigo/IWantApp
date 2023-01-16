namespace IWantApp.Endpoints.Orders;

public record OrderResponse(Guid Id, string clientEmail, IEnumerable<OrderProduct> Products, string DeliveryAddress);

public record OrderProduct(Guid id, string Name);