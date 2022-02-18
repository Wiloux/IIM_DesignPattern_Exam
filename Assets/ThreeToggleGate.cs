using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeToggleGate : MonoBehaviour
{
    public int ToggleNeeded = 3;

    [SerializeField]
    int currentActiveToggles;

    public void AddToggle()
    {
        currentActiveToggles++;

        if(currentActiveToggles == 3)
        {
            gameObject.SetActive(false);
        }
    }
    public void RemoveToggle()
    {
        currentActiveToggles--;
    }
}
