using UnityEngine;

public class ZombieCrawlState : EnemyState<Zombie>
{
    private int crawlCnt;
    private Vector3 crawlStartPos;

    public override void Enter(Zombie enemy)
    {
        enemy.Ani.SetBool("idle", false);
        enemy.Ani.SetBool("crawl", true);

        if (enemy.PlayerObj != null)
            enemy.transform.LookAt(enemy.PlayerObj.transform);

        crawlStartPos = enemy.transform.position;
    }

    public override void Update(Zombie enemy)
    {
        if (Vector3.Distance(enemy.transform.position, crawlStartPos) < enemy.CrawlDist)
        {
            enemy.transform.Translate(Vector3.forward * Time.deltaTime * enemy.CrawlSpeed);
            return;
        }

        ++crawlCnt;

        if (crawlCnt >= enemy.GoalCntToCrawl)
        {
            crawlCnt = 0;
            enemy.ChangeState(enemy.RemovingState);
            return;
        }

        enemy.ChangeState(enemy.IdleState);
    }

    public override void OnCollisionEnter(Zombie enemy, Collision coll)
    {
        if (coll.collider.CompareTag("Wall") || coll.collider.CompareTag("Player"))
            enemy.ReturnToPool();
    }
}
