using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] Sprite _bowSprite;
    [SerializeField] Sprite _shieldSprite;
    [SerializeField] Slider _healthSlider;
    [SerializeField] ControlShake _camShake;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public bool IsShielded;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction<int> OnHeal;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }


    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }


    void UpdateHealthSider(int newHealth)
    {
        if (newHealth < 0) return;

        _healthSlider.value = Mathf.Abs(newHealth);
    }

    public void TakeDamage(int amount)
    {

        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negative");

        if (IsShielded) return;

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        var delta = CurrentHealth - tmp;


        OnDamage?.Invoke(delta);

        if(_camShake)
        _camShake.LaunchScreenShake();

        if (CurrentHealth <= 0)
        {
            _onDeath?.Invoke();
        }
        
        if(_healthSlider)
        UpdateHealthSider(CurrentHealth);

    }

    public void Heal(int amount)
    {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negative");

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        var delta = CurrentHealth + tmp;
        UpdateHealthSider(CurrentHealth);
        OnHeal?.Invoke(delta);
    }


    public void isShielded(bool ON)
    {
        IsShielded = ON;

        _spriteRenderer.sprite = ON ? _shieldSprite : _bowSprite;
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while (enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }


}
