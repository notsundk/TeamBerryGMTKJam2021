using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private int Left = 0;
    private int Right = 0;

    Color RightHandColor;
    Color LeftHandColor;

    public Color[] LeftSelection = new Color[3];
    public Color[] RightSelection = new Color[3];

    // Start is called before the first frame update
    void Awake()
    {
        LeftSelection[0].r = 1; LeftSelection[1].r = 0; LeftSelection[2].r = 0; // 0 is red 1 is green  2 is blue
        LeftSelection[0].g = 0; LeftSelection[1].g = 1; LeftSelection[2].g = 0;
        LeftSelection[0].b = 0; LeftSelection[1].b = 0; LeftSelection[2].b = 1;

        RightSelection[0].r = 1; RightSelection[1].r = 0; RightSelection[2].r = 0;
        RightSelection[0].g = 0; RightSelection[1].g = 1; RightSelection[2].g = 0;
        RightSelection[0].b = 0; RightSelection[1].b = 0; RightSelection[2].b = 1;

        RightHandColor = RightSelection[0];
        LeftHandColor = LeftSelection[0];
    }

    private void Update()
    {
        RightHandColor = RightSelection[Right];
        LeftHandColor = LeftSelection[Left];
    }

    public void LeftHandCycleNext() { Left++;}
    public void LeftHandCycleBack() { Left--; }
    public void RightHandCycleNext() { Right++; }
    public void RightHandCycleBack() { Right--; }
    public void Fire()
    {

    }


}
