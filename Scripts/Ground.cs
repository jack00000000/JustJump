using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    public AudioClip loseaudio;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //游戏失败判定
    private void OnCollisionEnter2D(Collision2D other )
    {
        if (other.gameObject .tag  =="Player")
        {
            Playaudio(loseaudio);
            Gamemanager.Instance.gameover =true ;
        }
    }
    private  void Playaudio(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
