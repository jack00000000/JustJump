using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 第四关的两个检测台阶移动的trigger
/// </summary>

public class Trigger2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "taijie")
        {
            if (other.gameObject.GetComponent<RedTaijie2 >().goright == true)
            {
                other.gameObject.GetComponent<RedTaijie2 >().goright = false;
            }
            else if (other.gameObject.GetComponent<RedTaijie2 >().goright == false)
            {
                other.gameObject.GetComponent<RedTaijie2 >().goright = true;
            }
        }
    }
}
