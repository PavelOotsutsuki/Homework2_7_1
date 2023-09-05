using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private float _direction;
    private IDamagable _untarget;

    public void Init(IDamagable untarget)
    {
        _untarget = untarget;
        DefineDirection();
    }

    private void Update()
    {
        float rotation = transform.rotation.z;
    
        transform.Translate(new Vector2(_direction * (1 - rotation), 0 + rotation) * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_untarget is Player)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.ApplyDamage(_damage);

                Die();
            }
        }
        else if (_untarget is Enemy)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.ApplyDamage(_damage);

                Die();
            }
        }
        else
        {
            Debug.Log("Error _untarget");
        }
    }

    private void DefineDirection()
    {
        if (_untarget is Player)
        {
            _direction = -1;
        }
        else if (_untarget is Enemy)
        {
            _direction = 1;
        }
        else
        {
            Debug.Log("Error _untarget");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
