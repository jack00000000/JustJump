using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.gameObject.tag == "taijie")
        {
            if (other.gameObject.GetComponent<Redtaijie>().goright  == true)
            {
                other.gameObject.GetComponent<Redtaijie>().goright  = false;
            }
            else if (other.gameObject.GetComponent<Redtaijie>().goright  == false)
            {
                other.gameObject.GetComponent<Redtaijie>().goright  = true;
            }
        }
    }
}
