using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] PlayerLogic pl;
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform SpawnPoint;
    bool Check = true;
    int Score;
    void Start()
    {
        pl.Target = Instantiate(Enemy) as GameObject;
        pl.Target.transform.position = SpawnPoint.position;
    }

    void Update()
    {
        if(pl.Target.GetComponent<Enemy>().alive == false && Check == true) 
        {
            Check = false;
            Destroy(pl.Target.GetComponentInChildren<SpriteRenderer>());
            StartCoroutine(Spawn());
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
