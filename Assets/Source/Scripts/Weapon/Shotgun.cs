using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private const float QuaternionRadius = 0.05f;

    [SerializeField] private int _countBullets = 5; 

    public override void Shoot(Transform shootPoint, IDamagable untarget)
    {
        for (int i = 1; i <= _countBullets; i++)
        {
            int quaternionVector = (i % 2 * 2) - 1;
            int quaternion = i / 2;

            Bullet bullet = Instantiate(Bullet, shootPoint.position, new Quaternion(0f,0f,QuaternionRadius * quaternion * quaternionVector, 1f));
            bullet.Init(untarget);
        }
    }
}
