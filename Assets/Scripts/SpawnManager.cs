using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] spawnpoints;
    public float spawnrate;
    public float StartWait;
    public float WaitTimeBetweenSwarm;
    GameObject player;
    public GameObject[] Enemies;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(StartWait);

        while (!player.GetComponent<PlayerHealth>().die) {


            for (int i = 0; i < spawnpoints.Length; i++)
            {
                Vector3 here = spawnpoints[Random.Range(0,spawnpoints.Length)].transform.position;
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], here, Quaternion.identity);
                yield return new WaitForSeconds(spawnrate);


            }
            yield return new WaitForSeconds(WaitTimeBetweenSwarm);



        }

    }
   
}
