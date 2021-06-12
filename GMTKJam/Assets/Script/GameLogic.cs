using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] PlayerLogic pl;
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform SpawnPoint;
    bool Check = true;
    [SerializeField] ScoreTracker sc;
    [SerializeField] timer t;
    void Start()
    {
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
    }

    void Update()
    {
        if(pl.Target.GetComponent<Enemy>().alive == false && Check == true) 
        {
            sc.CurrentScore += 1;
            Check = false;
            Destroy(pl.Target.GetComponentInChildren<SpriteRenderer>());
            StartCoroutine(Spawn());
        }
        if(t.TimeRemaining <= 0)
        {
            if (sc.CurrentScore >= sc.HighScore)
            {
                sc.HighScore = sc.CurrentScore;
            }
            sc.CurrentScore = 0;
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
