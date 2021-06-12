using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLogic : MonoBehaviour
{
    private int Left = 0;
    private int Right = 0;

    [SerializeField] private Image LeftHand;
    [SerializeField] private Image RightHand;
    [SerializeField] private Image Spell;

    private Color RightHandColor;
    private Color LeftHandColor;
    private Color SpellColor;

    public Color[] LeftSelection = new Color[3];
    public Color[] RightSelection = new Color[3];

    public GameObject Target;

    void Awake()
    {
        LeftSelection[0].r = 1; LeftSelection[1].r = 0; LeftSelection[2].r = 0; // 0 is red 1 is green  2 is blue
        LeftSelection[0].g = 0; LeftSelection[1].g = 1; LeftSelection[2].g = 0;
        LeftSelection[0].b = 0; LeftSelection[1].b = 0; LeftSelection[2].b = 1;
        LeftSelection[0].a = 1; LeftSelection[1].a = 1; LeftSelection[2].a = 1;

        RightSelection[0].r = 1; RightSelection[1].r = 0; RightSelection[2].r = 0;
        RightSelection[0].g = 0; RightSelection[1].g = 1; RightSelection[2].g = 0;
        RightSelection[0].b = 0; RightSelection[1].b = 0; RightSelection[2].b = 1;
        RightSelection[0].a = 1; RightSelection[1].a = 1; RightSelection[2].a = 1;

        RightHandColor = RightSelection[0];
        LeftHandColor = LeftSelection[0];
    }
    
    private void Update()
    {
        RightHandColor = RightSelection[Right];
        LeftHandColor = LeftSelection[Left];
        SpellColor.r = LeftHandColor.r + RightHandColor.r;
        SpellColor.g = LeftHandColor.g + RightHandColor.g;
        SpellColor.b = LeftHandColor.b + RightHandColor.b;
        SpellColor.a = 1;
        if (SpellColor.r > 1) SpellColor.r = 1;
        if (SpellColor.g > 1) SpellColor.g = 1;
        if (SpellColor.b > 1) SpellColor.b = 1;


        LeftHand.color = LeftHandColor;
        RightHand.color = RightHandColor;
        Spell.color = SpellColor;
    }

    public void LeftHandCycleNext() 
    {
        if (Left == 2) 
            Left = 0;
        else
            Left++;
    }
    public void LeftHandCycleBack()
    {
        if (Left == 0)
            Left = 2;
        else
            Left--;
    }
    public void RightHandCycleNext() 
    {
        if (Right == 2)
            Right = 0;
        else
            Right++;
    }
    public void RightHandCycleBack()
    {
        if (Right == 0)
            Right = 2;
        else
            Right--;
    }
    public void Fire()
    {
        if(Target.GetComponentInChildren<SpriteRenderer>().color == SpellColor)
        {
            Target.GetComponent<Enemy>().alive = false;
        }
    }


}
