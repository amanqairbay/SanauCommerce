using MediatR;

namespace Basket.Application.Commands;

/// <summary>
/// Represents a delete basket command.
/// </summary>
public class DeleteBasketCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets the customer's username.
    /// </summary>
    public string UserName { get; set; }

    public DeleteBasketCommand(string userName)
    {
        UserName = userName;
    }
}