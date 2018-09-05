using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour {
    public Transform  m_player;
    private Transform m_trans;
    public GameObject m_playerr;
    private Rigidbody2D rig;
    private int m=2;
	// Use this for initialization
	void Start () {
        m_trans = this.transform;
     rig = m_playerr.GetComponent<Rigidbody2D>(); 
	}

    // Update is called once per frame
    void LateUpdate() {

        float y = m_player.position.y - m_trans.position.y;
        //相机跟随角色移动
        if ((y <= -3&&y >=-20)||y >=0)
        {
            if (m > 1.5f)
            {
                m_trans.position = Vector3.MoveTowards(m_trans.position, new Vector3(0, m_player.position.y, -10), 5 * Time.deltaTime);
            }
        }
        //若角色掉下，相机直接回到地面
        else  if (y<-20)
        {
            m -= 1;               
            m_trans.position =  new Vector3(0, -1f, -10);
           
        }
	}
}
