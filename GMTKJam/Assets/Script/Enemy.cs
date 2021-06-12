using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Color EnemyColor;
    public GameObject EnemySprite;
    public bool alive = true;

    public Color[] selection = new Color[6];

    private void Awake()
    {
        int rand = Random.Range(0, selection.Length);
        EnemyColor = selection[rand];
        EnemySprite.GetComponent<SpriteRenderer>().color = EnemyColor;
    }
}
