using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
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
        //通过手柄控制角色移动
        if (moveright==true )
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 10, transform.position.y, 0), 1 * Time.deltaTime);
        }
        if (moveleft==true )
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
        //按下跳跃，给角色添加一个向上的力
        if (canjump )
        {
            Gamemanager.Instance.Playaudio(jumpaudio);
            m_rig.AddForceAtPosition(new Vector2(0, 6), transform.position,ForceMode2D.Impulse);
            canjump = false;
        }
    }
   
   
    public void Onrightbutton()
    {
        moveright = true;
        moveleft = false;
    }
    public void Onjoystickup()
    {
        moveright = false ;
        moveleft = false; 
    }
    public void Onleftbutton()
    {
        moveleft  = true;
        moveright = false;
    }
   
}
