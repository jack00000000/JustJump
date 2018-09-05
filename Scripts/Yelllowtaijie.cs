using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 第四关的黄色台阶，可以生成下一台阶
/// </summary>
public class Yelllowtaijie : MonoBehaviour {
    //只能生成一次
    private int n=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (n >= 0.5f)
        {
            Gamemanager.Instance.Shengcheng(this.transform);
            n -= 1;
        }
        Gamemanager.Instance.Destryobj(this.gameObject);
        GetComponent<Animator>().enabled = true;
    }
}
