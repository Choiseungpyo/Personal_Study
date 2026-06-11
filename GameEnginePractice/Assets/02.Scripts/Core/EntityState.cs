using UnityEngine;

public abstract class EntityState<TEntity> where TEntity : MonoBehaviour
{
    public virtual void Enter(TEntity entity)
    {
    }

    public virtual void Update(TEntity entity)
    {
    }

    public virtual void FixedUpdate(TEntity entity)
    {
    }

    public virtual void OnCollisionEnter(TEntity entity, Collision coll)
    {
    }

    public virtual void OnCollisionExit(TEntity entity, Collision coll)
    {
    }
}
