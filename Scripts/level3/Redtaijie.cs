using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redtaijie : MonoBehaviour
{
    public bool goright;

    private bool taijiemove=false ;
    private Transform player_trans;

    // Use this for initialization
    void Start()
    {
        player_trans = GameObject.FindGameObjectWithTag("Player").GetComponent <Transform >(); 
        goright  = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("台阶：碰撞开始");
            taijiemove = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("台阶：碰撞中");
    }
   
    private void Update()
    {
        if (Mathf .Abs ( player_trans .position .y-transform .position .y)>=0.8)
        {
            taijiemove = false;
        }
        if (taijiemove)
        {
            if (goright)
            {
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(10, transform.position.y, 0), 0.5f * Time.deltaTime);
                transform.position += new Vector3(1, 0, 0) * 0.8f * Time.deltaTime;
            }
            else
            {
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-10, transform.position.y, 0), 0.5f * Time.deltaTime);
                transform.position += new Vector3(-1, 0, 0) * 0.8f * Time.deltaTime;
            }
        }

       
    
    }
}
