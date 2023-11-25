namespace EventBus.Messages.Events;

/// <summary>
/// Represents a base integration event class.
/// This class should be inherited by all event types in order to provide a consistent set of properties for the ID and Created date.
/// </summary>
public class IntegrationBaseEvent
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets or sets a creation date.
    /// </summary>
    public DateTime CreationDate { get; private set; }

    public IntegrationBaseEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    public IntegrationBaseEvent(Guid id, DateTime createDate)
    {
        Id = id;
        CreationDate = createDate;
    }
}