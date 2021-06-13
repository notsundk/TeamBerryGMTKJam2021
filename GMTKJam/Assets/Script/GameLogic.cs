using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    [SerializeField] PlayerLogic pl;
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform SpawnPoint;
    bool Check = true;

    [SerializeField] ScoreTracker sc;
    [SerializeField] timer t;

    int multiplier = 1;
    float BonusDuration = 2;
    bool bonus = false;
    public GameObject BonusBar;
    Vector3 BonusBarScale;
    public TextMeshProUGUI BonusMultiplier;


    public TextMeshProUGUI ScoreUI;

    void Start()
    {
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
        sc.CurrentScore = 0;
        BonusBarScale = BonusBar.transform.localScale;
    }

    void Update()
    {
        CountDown();

        ScoreUI.text = sc.CurrentScore.ToString();
        if(pl.Target != null)
        {
            if (pl.Target.GetComponent<Enemy>().alive == false && Check == true) //spawning new enemies
            {
                
                sc.CurrentScore += multiplier ;
                if(bonus)
                {
                    FindObjectOfType<AudioManager>().Play("BonusJingle");
                    multiplier += 1;
                }
                BonusDuration = 2;

                Check = false;
                Destroy(pl.Target.GetComponentInChildren<SpriteRenderer>());
                StartCoroutine(Spawn());
            }
        }
       

        if(bonus)
        {
            BonusDuration -= Time.deltaTime;
            float NewScale = BonusBarScale.x * (BonusDuration / 2.0f);
            BonusBar.transform.localScale = new Vector3(NewScale, BonusBarScale.y, 1);

            if(BonusDuration <= 0)
            {
                FindObjectOfType<AudioManager>().Play("BonusDecay");
                bonus = false;
                multiplier = 1;
            }
        }
        BonusMultiplier.text = "X" + multiplier.ToString();
    }

    void CountDown()
    {
        if (t.TimeRemaining <= 0)
        {
            if (sc.CurrentScore >= sc.HighScore)
            {
                sc.HighScore = sc.CurrentScore;
            }
            if (pl.Target != null)
                Destroy(pl.Target);
            Debug.Log("SNAKEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE!!!!!!!!");
            SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator Spawn()
    {
        GameObject temp = pl.Target;
        yield return new WaitForSeconds(0.001f);
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
        Destroy(temp);
        Check = true;

        bonus = true;

    }
}
