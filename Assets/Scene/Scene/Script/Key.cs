using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, IObject
{
    public GameObject door;


    public event UnityAction OnPickUp;

    public void PickUp(PlayerEntity target)
    {
        door.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
