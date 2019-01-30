using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _speed;
    public Transform Weapon;
    [SerializeField]
    public float turnspeed;
    public float movemultiplier;
    public float movemultipliercd;
    public float nextmovemultiplier;
    public float boostduration;
    void Start () {
        movemultiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Weapon.position;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Weapon.rotation = Quaternion.Euler(0, 0, z);

        Weapon.rotation = Quaternion.Slerp(Weapon.rotation,Quaternion.Euler(0,0,z),turnspeed * Time.deltaTime);
        Debug.DrawLine(Weapon.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));


        float horizontal =   Input.GetAxisRaw("Horizontal");
    float vertical =    Input.GetAxisRaw("Vertical");
        Vector3 Movement = new Vector3(horizontal, vertical, 0);

        transform.Translate(Movement.normalized * _speed  *movemultiplier * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        { if (Time.time > nextmovemultiplier)
                StartCoroutine(plusmovespeed());
            nextmovemultiplier = Time.time + movemultipliercd;
        }
          if (Input.GetKeyUp(KeyCode.Space))
            {
                movemultiplier = 1;
            }

    }
    IEnumerator plusmovespeed()
    {
        movemultiplier = 2;

        yield return new WaitForSeconds(boostduration);

        movemultiplier = 1;

    }
}
