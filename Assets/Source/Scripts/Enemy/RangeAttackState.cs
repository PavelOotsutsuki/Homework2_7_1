using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class RangeAttackState : AttackState
{
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Enemy _me;

    protected override void Attack(Player target)
    {
        Animator.Play(AnimationAttack);
        StartCoroutine(SpawnBullet(Animator.speed));
    }

    private IEnumerator SpawnBullet(float speed)
    {
        float time = 0;

        while (time < speed)
        {
            time += Time.deltaTime;
            yield return null;
        }

        SpawnBullet();
    }

    private void SpawnBullet()
    {
        Bullet bullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
        bullet.Init(_me);
    }
}
