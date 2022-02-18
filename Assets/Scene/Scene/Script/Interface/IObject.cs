using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IObject
{
    event UnityAction OnPickUp;

    public void PickUp(PlayerEntity target);
}

