using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;

    public Health Health => _health;

    private void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponentInParent<IObject>()?.PickUp(this);
    }



}


