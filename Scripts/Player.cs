using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D m_rig;
    private bool canjump;
    private bool moveright;
    private bool moveleft;
    public AudioClip jumpaudio;
	// Use this for initialization
	void Start () {
        m_rig = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	
    private void Update()
    {
        //通过安卓重力感应控制角色进行移动
        if (Input .acceleration .x >0 )
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 10, transform.position.y, 0), 1 * Time.deltaTime);
        }
        if (Input .acceleration .x <0 )
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 10, transform.position.y, 0), 1 * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)   
    {
        canjump = true;
    }
    
    public void jump()
    {
        //Debug.Log("按下jump"+"jump"+canjump ); 
        if (canjump )
        {
            //按下跳跃，给角色添加一个向上的力
            Gamemanager.Instance.Playaudio(jumpaudio);
            m_rig.AddForceAtPosition(new Vector2(0, 6), transform.position,ForceMode2D.Impulse);
            canjump = false;
        }
    }
   

}
