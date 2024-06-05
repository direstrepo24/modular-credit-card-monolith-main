namespace Common.SharedKernel.Domain;
public interface IEntityBase<TKey> : IAddEntity<TKey>, IUpdateEntity<TKey> { }
public interface IUpdateEntity<TKey> : IAddEntity<TKey>{ 
    
}

public interface IAddEntity<TKey>
{
    public TKey Id { get; set; }
}