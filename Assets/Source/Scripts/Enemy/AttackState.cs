using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AttackState : State
{
    protected const string AnimationAttack = "Attack";

    [SerializeField] private float _delay;

    private float _lastAttackTime;
    protected Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        _lastAttackTime = 0;
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    protected abstract void Attack(Player target);
}
