using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour, IObject
{
    public int healAmount;


    public event UnityAction OnPickUp;

    public void PickUp(PlayerEntity target)
    {
        target?.GetComponent<IHealth>().Heal(healAmount);
        Destroy(gameObject);
    }


  
}
