using System;
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

    public void Init()
    {
        IsBought = false;
    }

    public string GetLabel()
    {
        return Label;
    }

    public int GetPrice()
    {
        return Price;
    }

    public Sprite GetIcon()
    {
        return Icon;
    }

    public Bullet GetBullet()
    {
        return Bullet;
    }

    public bool GetIsBought()
    {
        return IsBought;
    }

    public abstract void Shoot(Transform shootPoint, IDamagable untarget);

    public void Buy()
    {
        IsBought = true;
    }
}
