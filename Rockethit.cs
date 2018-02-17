using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockethit : MonoBehaviour {
    public float weaponDam;
    RocketController  myPC;
    public GameObject explotionEffect;

	// Use this for initialization
	void Awake () {

        myPC = GetComponentInParent<RocketController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
