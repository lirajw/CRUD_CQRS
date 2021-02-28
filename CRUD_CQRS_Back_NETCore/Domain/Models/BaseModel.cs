using System;
namespace Domain.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }
    }
    
}
