using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {
    [Range(0, 1)]
    public float intensity;
    public Transform target;
    Vector3  initialpos;
    bool IsShaking = false;
    // Use this for initialization
    void Start () {
        target = GetComponent<Transform>();
        initialpos = target.localPosition;
	}
	float Pendingshakeduration;
	// Update is called once per frame
	public void Shake(float duration)
    {
        if (duration > 0)
        {
            Pendingshakeduration += duration;
        }


    }
 

    void Update()
    {

        if(Pendingshakeduration>0 && !IsShaking){
            StartCoroutine(DoShake());
        }

    }

    IEnumerator DoShake()
    {
        IsShaking = true;
        var Startime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < Startime + Pendingshakeduration)
        {

            var randompoint= new Vector3 (Random.Range(-1f,1f)*intensity , Random.Range(-1f, 1f) *intensity,initialpos.z);
            target.localPosition = randompoint;
            yield return null;
        }
       
        Pendingshakeduration = 0;
        target.localPosition = initialpos;
        IsShaking = false;


    }
}
