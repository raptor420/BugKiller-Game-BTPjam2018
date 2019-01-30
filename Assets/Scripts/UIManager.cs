using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Slider healthslider;
    public Text HealthText;
    public Image Fill;
    public Text ScoreText;
    public Text TimeUI;
    public GameObject RestartText;
    public Text HighscoreText;
     
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ShowCurrentHealth(float CurrenHealth)
    {

        healthslider.value = CurrenHealth;
        HealthText.text = CurrenHealth.ToString() + " HP";
        Fill.color = Color.Lerp(Color.black, Color.grey, CurrenHealth/ 100); 
        if (CurrenHealth >= 50)
        {
            //CHANGE TEXTCOLOR
          

        }
        else if (CurrenHealth < 50 && CurrenHealth > 30)
        {


        }
        else if(CurrenHealth <= 30)
        {


        }

    }
    public void UpdateScoreUII(int score)
    {

        ScoreText.text = "Score : " + score.ToString();
    }

    public void UpdateHS(int score)
    {
        HighscoreText.text = "HighScore : " + score.ToString();

    }
    public void UpdateTimeUII(float time)
    {

        TimeUI.text = "Time Survived " + System.Environment.NewLine  + time.ToString("n2");
    }

    public void RestartTextShow()
    {

        RestartText.SetActive(true);

    }

}
