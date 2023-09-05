using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint, IDamagable untarget)
    {
        Bullet bullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet.Init(untarget);
    }
}
