using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
public class CreateSaleCommand : IRequest<SaleResult>
{
    /// <summary>
    /// Gets the sales's customer unique ID.
    /// </summary>
    [Required]
    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the itens from this sale
    /// </summary>
    [Required]
    [JsonPropertyName("itensSale")]
    public List<ItemSale> ItensSale { get; set; } = [];

    public CreateSaleCommand(Guid customerId, List<ItemSale> itensSales) 
    {
        CustomerId = customerId;
        ItensSale = itensSales;
    }


}
