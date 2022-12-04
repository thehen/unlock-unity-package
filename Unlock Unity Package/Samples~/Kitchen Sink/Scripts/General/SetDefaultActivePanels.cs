using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultActivePanels : MonoBehaviour
{

    public GameObject[] startEnabledPanels;
    public GameObject[] startDisabledPanels;

    void Start()
    {
        foreach (var panel in startEnabledPanels)
        {
            panel.SetActive(true);
        }

        foreach (var panel in startDisabledPanels)
        {
            panel.SetActive(false);
        }
    }

}
