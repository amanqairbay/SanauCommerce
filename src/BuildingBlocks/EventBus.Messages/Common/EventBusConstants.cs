namespace EventBus.Messages.Common;

/// <summary>
/// Represents an event bus constants.
/// This is used to define constants for the name of the queues we will publish new messages to and consume from.
/// </summary>
public struct EventBusConstants
{
    public const string BasketCheckoutQueue = "basketcheckout-queue";
}