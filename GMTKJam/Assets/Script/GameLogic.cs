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

    public TextMeshProUGUI ScoreUI;

    void Start()
    {
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
        sc.CurrentScore = 0;
    }

    void Update()
    {
        ScoreUI.text = sc.CurrentScore.ToString();
        if(pl.Target != null)
        {
            if (pl.Target.GetComponent<Enemy>().alive == false && Check == true) //spawning new enemies
            {
                sc.CurrentScore += 1;
                Check = false;
                Destroy(pl.Target.GetComponentInChildren<SpriteRenderer>());
                StartCoroutine(Spawn());
            }
        }
        
        if(t.TimeRemaining <= 0)
        {
            if (sc.CurrentScore >= sc.HighScore)
            {
                sc.HighScore = sc.CurrentScore;
            }
            if(pl.Target != null)
                Destroy(pl.Target);
            Debug.Log("SNAKEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE!!!!!!!!");
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator Spawn()
    {
        GameObject temp = pl.Target;
        yield return new WaitForSeconds(1.0f);
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
        Destroy(temp);
        Check = true;
    }
}
