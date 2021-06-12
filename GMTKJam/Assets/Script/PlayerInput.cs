using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [System.NonSerialized] public bool LeftCycleNext = false;
    [System.NonSerialized] public bool LeftCycleBack = false;

    [System.NonSerialized] public bool RightCycleNext = false;
    [System.NonSerialized] public bool RightCycleBack = false;

    [System.NonSerialized] public bool Fire = false;

    // Update is called once per frame
    void Update()
    {
        LeftCycleNext = Input.GetKeyDown(KeyCode.E);
        LeftCycleBack = Input.GetKeyDown(KeyCode.Q);

        RightCycleNext = Input.GetKeyDown(KeyCode.O);
        RightCycleBack = Input.GetKeyDown(KeyCode.P);

        Fire = Input.GetKeyDown(KeyCode.Space);
    }
}
