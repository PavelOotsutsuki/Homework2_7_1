using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;

    private Transform _shootPoint;
    private Weapon _currentWeapon;
    private int _currentHealth;
    private int _currentWeaponIndex;
    //private Animator _animator;

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction Dying;

    public int CurrentHealth => _currentHealth;

    public int Money { get; private set; }

    public void Init()
    {
        //_animator = GetComponent<Animator>();
        _shootPoint = GetComponentInChildren<ShootPoint>().transform;
        _currentHealth = _health;
        _currentWeaponIndex = 0;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
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
        MoneyChanged?.Invoke(Money);
    }


    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.GetPrice();
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        _currentWeaponIndex++;

        if (_currentWeaponIndex >= _weapons.Count)
        {
            _currentWeaponIndex = 0;
        }

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        _currentWeaponIndex--;

        if (_currentWeaponIndex < 0)
        {
            _currentWeaponIndex = _weapons.Count - 1;
        }

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }


    private void Die()
    {
        Dying?.Invoke();
        Destroy(gameObject);
    }
}
