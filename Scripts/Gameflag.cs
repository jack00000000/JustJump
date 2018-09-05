using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameflag : MonoBehaviour {  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //小红点，若角色到达目标位置，游戏胜利
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other .name =="Player")
        {
            Gamemanager.Instance.WinGame ();
        }
    }
}
