using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    PlayerInput pi;
    PlayerLogic pl;

    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        pl = GetComponent<PlayerLogic>();
    }

    void Update()
    {
        if (pi.LeftCycleNext) { pl.LeftHandCycleNext(); }
        if (pi.LeftCycleBack) { pl.LeftHandCycleBack(); }
        
        if (pi.RightCycleNext) { pl.RightHandCycleNext(); }
        if (pi.RightCycleBack) { pl.RightHandCycleBack(); }

        if (pi.Fire) { pl.Fire(); }
    }
}
