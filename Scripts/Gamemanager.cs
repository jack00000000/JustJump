using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {
    //单例模式
    public  static Gamemanager _instance;
    public static Gamemanager  Instance{get
        {

            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager").GetComponent<Gamemanager>(); 
            }
            return _instance;
        }
    }
    //游戏中的一些button、panel
    public GameObject pausepanel;
    public GameObject Overpanel;
    public GameObject Winpanel;
    public GameObject m_player;
    public GameObject shoubing;
    
    public GameObject jump1;
    public GameObject jump2;
   
    public AudioClip winaudio;
    //台阶的数组，3个黄色，1个红色
    public GameObject[] zhangaiwu;
    //台阶数组的index
    private int ZAindex;
    //判断在左边还是右边生成
    private int x_index;
    public  bool gameover;
    public Transform m_camera;

    public Text haibatext;
    private void Awake()
    {
        int m = PlayerPrefs.GetInt ("moshi");
        if (m == 1)
        {
            m_player.GetComponent<Player>().enabled=true;
            m_player.GetComponent<Player1>().enabled=false ;
            jump1.SetActive(true);
            jump2.SetActive(false);
        }
        else
        {
            m_player.GetComponent<Player>().enabled = false ;
            m_player.GetComponent<Player1>().enabled = true ;
            shoubing .SetActive(true);
            
            jump1.SetActive(false );
            jump2.SetActive(true );  
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
         
    }
    //游戏结束
    public void GameOver()
    {
        
        Time.timeScale = 0;
        Overpanel.SetActive(true);
    }
    //游戏胜利
    public void WinGame()
    {
        Playaudio(winaudio);
        Time.timeScale = 0;
        Winpanel.SetActive(true);
    }
    //暂停按钮
    public void Onpausebutton()
    {
        Time.timeScale = 0;
        pausepanel.GetComponent<Animator>().SetBool("Onpause", true);
    }
    //继续按钮
    public void Onresumebutton()
    {
        Time.timeScale = 1;
        pausepanel.GetComponent<Animator>().SetBool("Onpause", false); 
    }
    //重新开始，本方法比较笨拙，待改进
    public void Retrybutton()
    {
        SceneManager.LoadScene(1);
    }
    public void Retrybutton02()
    {
        SceneManager.LoadScene(2);
    }
    public void Retrybutton03()
    {
        SceneManager.LoadScene(3);
    }
    public void Retrybutton04()
    {
        SceneManager.LoadScene(4);
    }
    //下一关卡
    public void Onnextbutton01()
    {
        SceneManager.LoadScene(2);
    }
    public void Onnextbutton02()
    {
        SceneManager.LoadScene(3);
    }
    public void Onnextbutton03()
    {
        SceneManager.LoadScene(4);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        //随机在左右两边生成
        x_index = Random.Range(0, 2);
        //台阶共有2种，黄色台阶生成几率为75%，红色几率为25%，所以数组为3个黄色台阶，一个红色台阶
        ZAindex = Random.Range(0, 4);
        float y = m_player.transform.position.y;
        int i = (int)y;
        haibatext.text = i.ToString()+"0米";
        if (PlayerPrefs .HasKey ("highscore"))
        {
            int temp = PlayerPrefs.GetInt("highscore");
            if (i > temp)
            {
                PlayerPrefs.SetInt("highscore", i);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", i);
        }
        if (gameover&&m_camera.position.y<=-0.7f)
        {
            GameOver(); 
        }
    }
   public  void Playaudio(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, m_player.transform.position);
    }
    public void Destryobj(GameObject obj)
    {
        Destroy(obj, 1.5f);
    }
    //生成下一台阶的逻辑
    public void Shengcheng(Transform trans)
    {
        if (trans.position.x ==4.5f)
        {
            Instantiate(zhangaiwu[ZAindex], new Vector3(3f, trans.position.y + 1.5f, 0), Quaternion.identity);
        }
        else if (trans.position.x ==-3f)
        {
            Instantiate(zhangaiwu[ZAindex], new Vector3(-1.5f, trans.position.y + 1.5f, 0), Quaternion.identity);
        }
        else
        {
            if (x_index >= 0 && x_index < 1)
            {
                Instantiate(zhangaiwu[ZAindex], new Vector3(trans.position.x + 1.5f, trans.position.y + 1.5f, 0), Quaternion.identity);
            }else
            {
                Instantiate(zhangaiwu[ZAindex], new Vector3(trans.position.x - 1.5f, trans.position.y + 1.5f, 0), Quaternion.identity);
            }
        }

    }
    
}
