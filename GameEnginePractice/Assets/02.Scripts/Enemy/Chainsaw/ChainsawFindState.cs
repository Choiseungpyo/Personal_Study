using UnityEngine;

public class ChainsawFindState : EnemyState<Chainsaw>
{
    public override void Enter(Chainsaw chainsaw)
    {
        chainsaw.Ani.SetBool("idle", false);
        chainsaw.Ani.SetBool("stun", false);
        chainsaw.Ani.SetBool("attack", false);
        chainsaw.Ani.SetTrigger("chainsawWalk");
        chainsaw.Ani.SetTrigger("chainsawStart");
    }

    public override void Update(Chainsaw chainsaw)
    {
        if (!chainsaw.CanMove)
        {
            chainsaw.CurrentFindDirIndex = chainsaw.ReverseFindDirIndex[chainsaw.CurrentFindDirIndex];
            chainsaw.FindStartPos = chainsaw.transform.position;
            chainsaw.CanMove = true;
            return;
        }

        Vector3 currentFindDir = chainsaw.FindDirs[chainsaw.CurrentFindDirIndex];
        chainsaw.transform.Translate(currentFindDir * Time.deltaTime * chainsaw.FindMoveSpeed, Space.World);
        chainsaw.transform.LookAt(chainsaw.transform.position + currentFindDir);

        if (Vector3.Distance(chainsaw.transform.position, chainsaw.FindStartPos) >= chainsaw.FindMoveDist)
        {
            int randDir = Random.Range(0, chainsaw.FindDirs.Length);
            while (randDir == chainsaw.CurrentFindDirIndex)
                randDir = Random.Range(0, chainsaw.FindDirs.Length);

            chainsaw.CurrentFindDirIndex = randDir;
            chainsaw.FindStartPos = chainsaw.transform.position;
        }

        if (chainsaw.PlayerObj == null)
            return;

        if (Vector3.Distance(chainsaw.PlayerObj.transform.position, chainsaw.transform.position) <= chainsaw.PlayerDetectDist)
            chainsaw.ChangeState(chainsaw.ChaseState);
    }

    public override void OnCollisionEnter(Chainsaw chainsaw, Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            chainsaw.CanMove = false;
            chainsaw.ChangeState(chainsaw.AttackState);
        }
        else if (coll.collider.CompareTag("Wall"))
        {
            chainsaw.CanMove = false;
        }
        else if (coll.collider.CompareTag("Object"))
        {
            chainsaw.CanMove = false;
            chainsaw.ChangeState(chainsaw.StunState);
        }
    }

    public override void OnCollisionExit(Chainsaw chainsaw, Collision coll)
    {
        if (coll.collider.CompareTag("Wall"))
            chainsaw.CanMove = true;
    }
}
