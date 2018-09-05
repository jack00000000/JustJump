using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panelmanager : MonoBehaviour {

    public GameObject mainpanel;
    public GameObject highscorepanel;
    public GameObject settingpanel;
    public Text highscoretext;
    private bool gou1;
    public GameObject zhongligou;
    public GameObject shoubinggou;
    public GameObject selectpanel;
    private void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            int i = PlayerPrefs.GetInt("highscore");
            highscoretext.text = i.ToString()+"0米";
        }else 
        {
            highscoretext.text = "0";
        }
        if (PlayerPrefs .HasKey ("moshi"))
        {
            int i = PlayerPrefs.GetInt("moshi");
            if (i==1)
            {
                gou1 = true;
            }else
            {
                gou1 = false;
            }
        }else
        {
            PlayerPrefs.SetInt("moshi", 1);
            gou1 = true;
        }
    }
    public void Onstartbutton()
    {
        mainpanel.GetComponent<Animator>().SetBool("yincang", true);
        selectpanel.SetActive(true);
    }
    public void Onexitbutton() 
    {
        Application.Quit();
    }
    public void Onhighscorebutton()
    {
        mainpanel.GetComponent<Animator>().SetBool("yincang", true);
        highscorepanel.SetActive(true);

    }
    //设置菜单
    public void Onsettingbutton()
    {
        if (gou1 )
        {
            zhongligou.SetActive(true);
            shoubinggou.SetActive(false);
        }else
        {
            zhongligou.SetActive(false );
            shoubinggou.SetActive(true );
        }
        mainpanel.GetComponent<Animator>().SetBool("yincang", true);
        settingpanel.SetActive(true); 
    }
    //返回按钮
    public void Onfanhuibutton()
    {
        mainpanel.GetComponent<Animator>().SetBool("yincang", false );
        highscorepanel.SetActive(false);
        settingpanel.SetActive(false);
        selectpanel.SetActive(false);
    }
    //操作模式选择
    public void Onzhonglibutton()
    {
        PlayerPrefs.SetInt("moshi", 1);
        zhongligou.SetActive(true);
        shoubinggou.SetActive(false );
    }
    public void Onshoubingbutton()
    {
        PlayerPrefs.SetInt("moshi", 2);
        shoubinggou.SetActive(true);
        zhongligou.SetActive(false );
    }
    //关卡选择
    public void Onlevel1button()
    {
        SceneManager.LoadScene(1);

    }
    public void Onlevel2button()
    {
        SceneManager.LoadScene(2);

    }
    public void Onlevel3button()
    {
        SceneManager.LoadScene(3);

    }
    public void Onlevel4button()
    {
        SceneManager.LoadScene(4);

    }

}
