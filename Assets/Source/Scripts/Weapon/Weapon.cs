using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string Label;
    [SerializeField] protected int Price;
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected bool IsBought = false;

    public abstract void Shoot(Transform shootPoint, IDamagable untarget);
}
