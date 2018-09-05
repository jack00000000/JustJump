using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taijie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //普通黄色台阶，碰到角色后1.5s销毁
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Gamemanager.Instance.Destryobj(this.gameObject);
        GetComponent<Animator>().enabled = true;
    }
}
