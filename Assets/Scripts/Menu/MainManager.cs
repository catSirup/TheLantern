using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

    TopManager s_Manager;
    Transform t_Title;
    Transform t_Develop;
    Transform t_Tutorial;
    MenuSelect s_Start;
    MenuSelect s_Develop;
    MenuSelect s_Tutorial;

    public enum MainState { Title, Start, Tutorial, Develop, Quit };

    private MainState curState;

    void Awake() { Init(); }

    void Update() { ActiveMain();}

    void Init()
    {
        s_Manager = GameObject.Find("Managers").GetComponent<TopManager>();

        t_Title     = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Title").transform;
        t_Tutorial  = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Tutorial").transform;
        t_Develop   = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Develop").transform;

        s_Start     = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Title").transform.FindChild("Main_Start").GetComponent<MenuSelect>();
        s_Develop   = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Title").transform.FindChild("Main_Develop").GetComponent<MenuSelect>();
        s_Tutorial  = GameObject.Find("Managers").transform.FindChild("Main").transform.FindChild("Title").transform.FindChild("Main_Tutorial").GetComponent<MenuSelect>();

        if (s_Manager.curState == TopManager.ManagerActiveState.MAIN)
        {
            curState = MainState.Title;
        }
    }

    void ActiveMain()
    {
        switch (curState)
        {
            case MainState.Title:
                t_Title.gameObject.SetActive(true);
                t_Develop.gameObject.SetActive(false);
                t_Tutorial.gameObject.SetActive(false);
                break;

            case MainState.Start:
                t_Title.gameObject.SetActive(false);
                t_Develop.gameObject.SetActive(false);
                t_Tutorial.gameObject.SetActive(false);
                s_Start.SpriteRenderer.sprite = s_Start.sp_Off;
                s_Manager.curState = TopManager.ManagerActiveState.PROLOGUE;
                break;

            case MainState.Tutorial:
                t_Title.gameObject.SetActive(false);
                t_Develop.gameObject.SetActive(false);
                t_Tutorial.gameObject.SetActive(true);
                s_Tutorial.SpriteRenderer.sprite = s_Tutorial.sp_Off;
                break;

            case MainState.Develop:
                t_Title.gameObject.SetActive(false);
                t_Develop.gameObject.SetActive(true);
                t_Tutorial.gameObject.SetActive(false);
                s_Develop.SpriteRenderer.sprite = s_Develop.sp_Off;
                break;

            case MainState.Quit:
                Application.Quit();
                break;
        }
    }

    public MainState mainState
    {
        get { return curState; }
        set { curState = value; }
    }
}
