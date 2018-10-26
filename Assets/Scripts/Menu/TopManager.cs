using UnityEngine;
using System.Collections;

public class TopManager : MonoBehaviour
{
    // Manager Class 변수
    Transform t_MainManager;            // 메인 타이틀 관리
    Transform t_Prologue;
    Transform t_StageManager;           // 스테이지 관리
    Transform t_Endingmanager;          // 엔딩 관리
    Transform t_Epilogue;

    // Manager Class별 State Value
    public enum ManagerActiveState { MAIN = 0, PROLOGUE, STAGE, ENDING, EPILOGUE };

    private ManagerActiveState ev_CurState;   // 현재 게임 신이 어디인지 알려주는 변수.

    void Awake() { Init(); }

    void Update() { ActiveManagers(); }


    // 사용자 정의 함수.
    void Init()
    {
        t_StageManager  = GameObject.Find("Managers").transform.FindChild("Stage");
        t_Prologue      = GameObject.Find("Managers").transform.FindChild("Prologue");
        t_MainManager   = GameObject.Find("Managers").transform.FindChild("Main");
        t_Endingmanager = GameObject.Find("Managers").transform.FindChild("Ending");
        t_Epilogue      = GameObject.Find("Managers").transform.FindChild("Epilogue");

        t_StageManager.gameObject.SetActive(false);
        t_MainManager.gameObject.SetActive(false);
        t_Endingmanager.gameObject.SetActive(false);
        t_Prologue.gameObject.SetActive(false);
        t_Epilogue.gameObject.SetActive(false);

        ev_CurState = ManagerActiveState.MAIN;
    }

    void ActiveManagers()
    {
        switch (ev_CurState)
        {
            case ManagerActiveState.MAIN:
                t_MainManager.gameObject.SetActive(true);
                t_Prologue.gameObject.SetActive(false);
                t_StageManager.gameObject.SetActive(false);
                t_Endingmanager.gameObject.SetActive(false);
                t_Epilogue.gameObject.SetActive(false);
                break;

            case ManagerActiveState.PROLOGUE:
                t_MainManager.gameObject.SetActive(false);
                t_Prologue.gameObject.SetActive(true);
                t_StageManager.gameObject.SetActive(false);
                t_Endingmanager.gameObject.SetActive(false);
                t_Epilogue.gameObject.SetActive(false);
                break;

            case ManagerActiveState.STAGE:
                t_MainManager.gameObject.SetActive(false);
                t_Prologue.gameObject.SetActive(false);
                t_StageManager.gameObject.SetActive(true);
                t_Endingmanager.gameObject.SetActive(false);
                t_Epilogue.gameObject.SetActive(false);
                break;

            case ManagerActiveState.ENDING:
                t_MainManager.gameObject.SetActive(false);
                t_Prologue.gameObject.SetActive(false);
                t_StageManager.gameObject.SetActive(false);
                t_Endingmanager.gameObject.SetActive(true);
                t_Epilogue.gameObject.SetActive(false);
                break;

            case ManagerActiveState.EPILOGUE:
                t_MainManager.gameObject.SetActive(false);
                t_Prologue.gameObject.SetActive(false);
                t_StageManager.gameObject.SetActive(false);
                t_Endingmanager.gameObject.SetActive(false);
                t_Epilogue.gameObject.SetActive(true);
                break;
        }
    }

    public ManagerActiveState curState
    {
        get { return ev_CurState; }
        set { ev_CurState = value; }
    }

}
