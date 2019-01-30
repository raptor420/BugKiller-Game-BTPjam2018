using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
  public   int score;
    [SerializeField]
    int  HighScore;
    float Timer;
    UIManager uimanager;
    GameObject player;
	// Use this for initialization
	void Start () {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
      
        player = GameObject.FindGameObjectWithTag("Player");
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        UpdateScore(0);
        uimanager.UpdateTimeUII(Timer);
        uimanager.UpdateHS(HighScore);
    }
	
	// Update is called once per frame
	void Update () {
        if (!player.GetComponent<PlayerHealth>().die)
        uimanager.UpdateTimeUII(Timer);
        Timer += Time.deltaTime;
	}

  public void UpdateScore(int points)
    {
        score = score + points;
        uimanager.UpdateScoreUII(score);
        if(score > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
           uimanager.UpdateHS(score);


        }
        

    }
}
