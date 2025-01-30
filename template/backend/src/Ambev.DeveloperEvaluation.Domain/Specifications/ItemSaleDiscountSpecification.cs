using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ItemSaleDiscountSpecification : ISpecification<ItemSale>
{
    public decimal ApplyDiscount(ItemSale itemSale)
    {
        if (itemSale.Quantity > 4)
        {
            // Aplica 10% de desconto
            return itemSale.TotalAmount * 0.90m;
        }
        else if (itemSale.Quantity >= 10 && itemSale.Quantity <= 20)
        {
            // Aplica 20% de desconto
            return itemSale.TotalAmount * 0.80m;
        }
        else
        {
            // Não aplica desconto
            return itemSale.TotalAmount;
        }
    }

    public bool IsSatisfiedBy(ItemSale itemSale)
    {
        return itemSale.Quantity > 4 || (itemSale.Quantity >= 10 && itemSale.Quantity <= 20);
    }
}
