using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public GameObject potion;

    public void Touch(int power)
    {
        int rdm = Random.RandomRange(0, 3);
        if (rdm == 1)
            Instantiate(potion, transform.position, Quaternion.identity);

            Destroy(gameObject);
    }
}
