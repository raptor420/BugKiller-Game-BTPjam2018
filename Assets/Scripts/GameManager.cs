using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    PlayerHealth playerhealth;
    UIManager um;
	// Use this for initialization
	void Start () {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        um = GameObject.Find("Canvas").GetComponent<UIManager>();

        playerhealth.OnDeath += RestartGame;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RestartGame()
    {
        um.RestartTextShow();
        

    }
}
