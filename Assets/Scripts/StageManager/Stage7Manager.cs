using UnityEngine;
using System.Collections;

public class Stage7Manager : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Switch s_Switch;
    Switch s_Switch1;
    Switch s_Switch2;
    Tower s_Tower;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Transform t_TimeStep1;
    Transform t_TimeStep2;
    Transform t_TimeStep3;
    Transform t_TimeStep4;
    Ladder s_Ladder;
    StageManager s_StageManager;

    bool b_IsOnStep1;
    bool b_IsOnStep2;
    bool b_IsOnStep3;
    bool b_IsOnStep4;
    
    void OnEnable() { Init(); }

    void Awake() { StageClearValue.i_CurStageLevel = 7; }

    void Init()
    {
        s_Player = GameObject.Find("Stage7").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Ove = GameObject.Find("Stage7").transform.FindChild("Ove").GetComponent<Ove>();
        s_Switch = GameObject.Find("Stage7").transform.FindChild("Switch").GetComponent<Switch>();
        s_Switch1 = GameObject.Find("Stage7").transform.FindChild("Switch1").GetComponent<Switch>();
        s_Switch2 = GameObject.Find("Stage7").transform.FindChild("Switch2").GetComponent<Switch>();
        s_Tower = GameObject.Find("Stage7").transform.FindChild("Tower").GetComponent<Tower>();
        s_Flower1 = GameObject.Find("Stage7").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage7").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage7").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        t_TimeStep1 = GameObject.Find("Stage7").transform.FindChild("TimeStep1").transform;
        t_TimeStep2 = GameObject.Find("Stage7").transform.FindChild("TimeStep2").transform;
        t_TimeStep3 = GameObject.Find("Stage7").transform.FindChild("TimeStep3").transform;
        t_TimeStep4 = GameObject.Find("Stage7").transform.FindChild("TimeStep4").transform;
        s_Ladder = GameObject.Find("Stage7").transform.FindChild("Ladder").GetComponent<Ladder>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(3.4f, -33.3f, 0);
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(12.6f, -36, -1);
        s_Switch.Init();
        s_Switch1.Init();
        s_Switch2.Init();
        s_Tower.Init();
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        t_TimeStep1.gameObject.SetActive(false);
        t_TimeStep2.gameObject.SetActive(false);
        t_TimeStep3.gameObject.SetActive(false);
        t_TimeStep4.gameObject.SetActive(false);
        s_Ladder.Init();

        b_IsOnStep1 = false;
        b_IsOnStep2 = false;
        b_IsOnStep3 = false;
        b_IsOnStep4 = false;
    }

    void Update()
    {
        s_Ove.ActiveOve();
        s_Switch.ActiveSwitch();
        s_Switch1.ActiveSwitch();
        s_Switch2.ActiveSwitch();
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_Ladder.ActiveLadderCheck();
        s_Tower.ActiveTower();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s_Ove.transform.parent = s_Tower.transform.parent;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }

        ActiveTimeStep();
    }

    void FixedUpdate()
    {
        s_Player.ActivePlayer();
    }

    void ActiveTimeStep()
    {
        if (s_Switch1.switchState)
        {
            if (!b_IsOnStep1)
            {
                StartCoroutine(DisalbeTimeStep1());
                b_IsOnStep1 = !b_IsOnStep1;
            }

            if (!b_IsOnStep2)
            {
                StartCoroutine(DisalbeTimeStep2());
                b_IsOnStep2 = !b_IsOnStep2;
            }
        }
        else
        {
            t_TimeStep1.gameObject.SetActive(false);
            t_TimeStep2.gameObject.SetActive(false);
            b_IsOnStep1 = false;
            b_IsOnStep2 = false;
        }

        if (s_Switch2.switchState)
        {
            if (!b_IsOnStep3)
            {
                StartCoroutine(DisalbeTimeStep3());
                b_IsOnStep3 = !b_IsOnStep3;
            }

            if (!b_IsOnStep4)
            {
                StartCoroutine(DisalbeTimeStep4());
                b_IsOnStep4 = !b_IsOnStep4;
            }
        }

        else
        {
            t_TimeStep3.gameObject.SetActive(false);
            t_TimeStep4.gameObject.SetActive(false);
            b_IsOnStep3 = false;
            b_IsOnStep4 = false;
        }
    }

    IEnumerator DisalbeTimeStep1()
    {
        t_TimeStep1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        t_TimeStep1.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        b_IsOnStep1 = !b_IsOnStep1;
    }

    IEnumerator DisalbeTimeStep2()
    {
        yield return new WaitForSeconds(1.5f);
        t_TimeStep2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        t_TimeStep2.gameObject.SetActive(false);
        b_IsOnStep2 = !b_IsOnStep2;
    }

    IEnumerator DisalbeTimeStep3()
    {
        t_TimeStep3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        t_TimeStep3.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        b_IsOnStep3 = !b_IsOnStep3;
    }

    IEnumerator DisalbeTimeStep4()
    {
        yield return new WaitForSeconds(2.5f);
        t_TimeStep4.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        t_TimeStep4.gameObject.SetActive(false);
        b_IsOnStep4 = !b_IsOnStep4;
    }

    public bool IsOnStep1
    {
        get { return b_IsOnStep1; }
        set { b_IsOnStep1 = value; }
    }
}
