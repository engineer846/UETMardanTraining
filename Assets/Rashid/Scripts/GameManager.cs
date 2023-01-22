using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;

    //For UI
    public Text ScoreText;
    public Slider HealthSlider;

    public GameObject PausePanel;
    public GameObject GameWonPanel;
    public GameObject GameFailedPanel;

    public bool isGameWon = false;
    public bool isGameOver = false;


    public int Score = 0;
    int index = 0;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SpawnEnemy();
        UpdateUIElement();
    }

    private void Update()
    {
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

    public void GameOver()
    {
        Time.timeScale = 0;
        GameFailedPanel.SetActive(true);
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        GameWonPanel.SetActive(true);
    }

    public void UpdateUIElement()
    {
        ScoreText.text = Score.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
