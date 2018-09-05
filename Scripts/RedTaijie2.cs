using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTaijie2 : MonoBehaviour {
    //判断红色台阶移动方向
    public bool goright;
    //判断台阶能否移动
    private bool taijiemove = false;
    //获取角色位置
    private Transform player_trans;
    //每个台阶只能生成一次下一台阶
    private int n = 1;

    // Use this for initialization
    void Start()
    {
        player_trans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        goright = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //若碰到角色，生成下一台阶
        if (collision.gameObject.tag == "Player")
        {
            if (n >= 0.5f)
            {
                Gamemanager.Instance.Shengcheng(this.transform);
                n -= 1;
            }
            Debug.Log("台阶：碰撞开始");
            taijiemove = true;
        }
    }
    

    private void Update()
    {
        //若角色跳起，台阶停止移动
        if (Mathf.Abs(player_trans.position.y - transform.position.y) >= 0.8)
        {
            taijiemove = false;
        }
        //若角色高于台阶3f，销毁台阶
        if ((player_trans .position .y-transform .position .y )>=3f)
        {
            Gamemanager.Instance.Destryobj(this.gameObject);
        }
        if (taijiemove)
        {
            if (goright)
            {   //向右移动             
                transform.position += new Vector3(1, 0, 0) * 0.8f * Time.deltaTime;
            }
            else
            {   //向左移动             
                transform.position += new Vector3(-1, 0, 0) * 0.8f * Time.deltaTime;
            }
        }



    }
}
