using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    // Use this for initialization
    AudioSource sound;
	void Start () {
        sound = GetComponent<AudioSource>();
        sound.Play();
        Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
