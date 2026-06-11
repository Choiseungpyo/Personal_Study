using UnityEngine;

public class ChainsawChaseState : EnemyState<Chainsaw>
{
    public override void Enter(Chainsaw chainsaw)
    {
        chainsaw.Ani.SetBool("idle", false);
        chainsaw.Ani.SetBool("stun", false);
        chainsaw.Ani.SetBool("attack", false);
        chainsaw.Ani.SetTrigger("chainsawRun");
    }

    public override void Update(Chainsaw chainsaw)
    {
        if (chainsaw.PlayerObj == null)
            return;

        Vector3 dir = (chainsaw.PlayerObj.transform.position - chainsaw.transform.position).normalized;
        Quaternion targetDir = Quaternion.LookRotation(dir);
        chainsaw.transform.rotation = Quaternion.Slerp(chainsaw.transform.rotation, targetDir, Time.deltaTime * chainsaw.TurnSpeed);

        if (chainsaw.CanMove)
            chainsaw.transform.position += dir * chainsaw.ChaseSpeed * Time.deltaTime;
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
