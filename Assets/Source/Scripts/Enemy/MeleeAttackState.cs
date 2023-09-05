using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    [SerializeField] private int _damage;

    protected override void Attack(Player target)
    {
        Animator.Play(AnimationAttack);
        target.ApplyDamage(_damage);
    }
}
