using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField]
    private float EnemyHealth;
    [SerializeField]
    private float Power;
    GameObject player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LayerMask Playerlayer;
    public float NextAttackTime;
    public float TimeBetweenAttacks;
    private bool PlayerAlive;
    public int Scorepoint;
    ScoreManager ScoreM;
    public GameObject Explosionfx;
    Shaker shaker;
    AudioSource playerhurt;


        void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ScoreM = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shaker>();
        playerhurt = GetComponent<AudioSource>();
       // Playerlayer = player.layer;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(!player.GetComponent<PlayerHealth>().die)
            ChasePlayer();
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        //if(other.tag == "Player")
        //{
        //    PlayerHealth health =  other.GetComponent<PlayerHealth>();
        //    health.TakeDamage(Power);

        //} //else if
         if (other.tag == "Bullets")
        {
            Bullets bullets = other.GetComponent<Bullets>();
            TakeDamage(bullets.Damage);
        }
    }

   void ChasePlayer()
    {
       Vector3 PlayerPos = player.transform.position;
        if (Vector2.Distance(player.transform.position, transform.position) >.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(player.transform.position, transform.position)  <= .5)
        { if (Time.time > NextAttackTime)
            {
                AttackPlayer();
                NextAttackTime = TimeBetweenAttacks + Time.time;
            }
        }

    }
        
    void AttackPlayer()
    { Vector2 dir = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,10,Playerlayer);
        if (hit)
        {
             
            Debug.Log("we hit em" + hit.collider.name);
            PlayerHealth health =  hit.collider.GetComponent<PlayerHealth>();
            health.TakeDamage(Power);
             Vector2 hitme = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            hit.collider.GetComponent<Rigidbody2D>().AddForce(hitme * 10, ForceMode2D.Impulse);
            playerhurt.Play();

        }

     


    }
    void TakeDamage(int  damage)
    { if (EnemyHealth < 1)
        {
            Instantiate(Explosionfx, transform.position, Quaternion.identity);
            Die();
          
        }
    else
        {
            EnemyHealth -= damage;

        }
        

    }
    void Die()
    {
        Instantiate(Explosionfx, transform.position, Quaternion.identity);
        shaker.Shake(.05f);
        ScoreM.UpdateScore(Scorepoint);
        Destroy(this.gameObject);

    }

    void OnPlayerDeath()
    {
        PlayerAlive = false;


    }
}
