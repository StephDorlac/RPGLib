using System;

namespace RPGLibEntityCore.Entities
{
    public interface IBaseEntity<T>
    {
        public Guid internalId { get; set; }
    }
}