using System.Collections;
using UnityEngine;

public class ChainsawAttackState : EnemyState<Chainsaw>
{
    public override void Enter(Chainsaw chainsaw)
    {
        chainsaw.Ani.SetBool("idle", false);
        chainsaw.Ani.SetBool("stun", false);
        chainsaw.Ani.SetBool("attack", true);
        chainsaw.StartCoroutine(DisableWeaponCollider(chainsaw));
    }

    private IEnumerator DisableWeaponCollider(Chainsaw chainsaw)
    {
        BoxCollider weaponCollider = chainsaw.Weapon == null ? null : chainsaw.Weapon.GetComponent<BoxCollider>();
        if (weaponCollider == null)
            yield break;

        yield return new WaitForSeconds(0.5f);
        weaponCollider.enabled = false;
    }
}
