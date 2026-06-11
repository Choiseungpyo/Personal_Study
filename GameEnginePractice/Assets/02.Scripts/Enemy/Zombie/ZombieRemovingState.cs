using UnityEngine;

public class ZombieRemovingState : EnemyState<Zombie>
{
    private float elapsedTime;

    public override void Enter(Zombie enemy)
    {
        elapsedTime = 0f;
        enemy.Ani.SetBool("idle", true);
        enemy.Ani.SetBool("crawl", false);
    }

    public override void Update(Zombie enemy)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1f)
            enemy.ReturnToPool();
    }

    public override void OnCollisionEnter(Zombie enemy, Collision coll)
    {
        if (coll.collider.CompareTag("Wall") || coll.collider.CompareTag("Player"))
            enemy.ReturnToPool();
    }
}
