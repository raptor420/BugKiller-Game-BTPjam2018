using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private float healthValue;
    UIManager uimanager;
    public bool die;
    public event System.Action OnDeath;

    void Start () {
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uimanager.ShowCurrentHealth(healthValue);


    }

    // Update is called once per frame
    void Update () {
        if (healthValue <= 0)
        {
            Die();

        }
    }

  


    
   public void TakeDamage(float Damage)
    {

        if(healthValue>0)
        {
            healthValue -= Damage;
            Debug.Log(healthValue);
            uimanager.ShowCurrentHealth(healthValue);
        }

    }

    void Die()
    {
        die = true;
        OnDeath();
        Destroy(this.gameObject);

    }
}
