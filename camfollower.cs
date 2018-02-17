using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollower : MonoBehaviour {

    public Transform target;
    public float smoothering;

    Vector3 offset;
    float lowY;

	// Use this for initialization
	void Start () {
        offset = transform.position + offset;
        lowY = transform.position.y-5;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetcampos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetcampos, smoothering * Time.deltaTime);
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
	}
}
