using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float TimeRemaining;
    float StartingTime;
    float StartingScale;
    public RectTransform TimerBar;
    public Image bar;
    private void Start()
    {
        StartingTime = TimeRemaining;
        StartingScale = TimerBar.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        float scaler = (TimeRemaining / StartingTime);
        float NewScaleX = StartingScale * scaler;
        TimerBar.localScale = new Vector3(NewScaleX, 1, 1);

        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("SNAKEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE!!!!!!!!");
            Time.timeScale = 0;
        }

        if (scaler < 0.2f)
        {
            bar.color = new Color(1, 0, 0);
        }
        else if (scaler < 0.4f)
        {
            bar.color = new Color(1, 125f/255f, 0); 
        }
        else if (scaler < 0.6f)
        {
            bar.color = new Color(1, 1, 0);
        }


    }
}
