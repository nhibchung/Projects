using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLerp : MonoBehaviour {

    public float cloudSpeed = 0.5f;
    private Vector3 point1;
    private Vector3 point2;

	// Use this for initialization
	void Start () {
        point1 = gameObject.transform.position + new Vector3(0, 0, 15);
        point2 = gameObject.transform.position + new Vector3(0, 0, -15);
    }
	
	// Update is called once per frame
	void Update () {
        //Time represents interpolant t in lerp. t is commonly used to find a point some fraction along point 1 and 2
        float time = Mathf.PingPong(Time.time * cloudSpeed, 1);     
        transform.position = Vector3.Lerp(point1, point2, time);
	}
}
