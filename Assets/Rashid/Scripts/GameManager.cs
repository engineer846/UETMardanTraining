using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;

    public int Score = 0;
    int index = 0;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SpawnEnemy();
    }

    private void Update()
    {
        //if(Score >= 10)
        //{
        //    print("Game Won!");
        //}
    }


    public void SpawnEnemy()
    {
        //int index = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[index].position, SpawnPoints[index].rotation);
        if (index < 2)
            index++;
        else
        {
            index = 0;
        }
    }
}
