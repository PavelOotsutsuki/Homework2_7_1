using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon[] _weapons;

    private Transform _shootPoint;
    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;

    public event UnityAction<int,int> HealthChanged;

    public int CurrentHealth => _currentHealth;

    public int Money { get; private set; }

    public void Init()
    {
        _animator = GetComponent<Animator>();
        _shootPoint = GetComponentInChildren<ShootPoint>().transform;
        _currentHealth = _health;
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint, this);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
