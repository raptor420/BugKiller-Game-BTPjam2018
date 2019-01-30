using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public float NextFire;
    public float FireRate;
    public Transform Weapon;
    public Transform FirePos;
    public float range;
    public GameObject Bullets;
    public GameObject MuzzleFlash;
    Shaker shaker;
    AudioSource gunshot;
  //  public LayerMask Enemylayer;


	void Start () {
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shaker>();
        gunshot = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

       

        if (Input.GetMouseButton(0))
        {
            if(Time.time > NextFire)
            {
                StartCoroutine("flash");
                Instantiate(Bullets, FirePos.position, Weapon.rotation);
                gunshot.Play();
                shaker.Shake(.01f);




                NextFire = Time.time + FireRate;
            }

        }
	}

    IEnumerator flash()
    {
        MuzzleFlash.SetActive(true);
        yield return new  WaitForSeconds(.1f);
        MuzzleFlash.SetActive(false);
    }
}
