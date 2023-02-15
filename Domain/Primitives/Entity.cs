using System;

namespace Domain.Primitives;

/// <summary>
/// Base entity class
/// </summary>
public abstract class Entity
{
    protected Entity(Guid id) => Id = id;

    protected Entity()
    {
    }

    public Guid Id { get; set; }
}