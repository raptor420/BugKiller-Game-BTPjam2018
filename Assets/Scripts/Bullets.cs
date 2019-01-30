using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public float speed;
    public int Damage;

        void Start () {
        Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
		
	}


void     OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("hit");
            Destroy(this.gameObject);

        }

    }
}
