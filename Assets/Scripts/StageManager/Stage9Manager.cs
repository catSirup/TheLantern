using UnityEngine;
using System.Collections;

public class Stage9Manager : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Ladder s_Ladder;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Tower s_Tower;
    Transform t_TimeStep1;
    Transform t_TimeStep2;
    RailStep s_RailStep1;
    StageManager s_StageManager;
    Switch s_Switch;
    Switch s_Switch2;
    Switch s_Switch3;
    Switch s_Switch4;
    RotateStep s_RotateStep;

    bool b_IsOnStep1;
    bool b_IsOnStep2;


    void OnEnable() { Init(); }

    void Awake() { StageClearValue.i_CurStageLevel = 9; }
    
    void Init()
    {
        s_Player = GameObject.Find("Stage9").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Ove = GameObject.Find("Stage9").transform.FindChild("Ove").GetComponent<Ove>();
        s_Ladder = GameObject.Find("Stage9").transform.FindChild("Ladder").GetComponent<Ladder>();
        s_Flower1 = GameObject.Find("Stage9").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage9").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage9").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_Tower = GameObject.Find("Stage9").transform.FindChild("Tower").GetComponent<Tower>();
        s_RailStep1 = GameObject.Find("Stage9").transform.FindChild("RailStep1").GetComponent<RailStep>();
        t_TimeStep1 = GameObject.Find("Stage9").transform.FindChild("TimeStep1").transform;
        t_TimeStep2 = GameObject.Find("Stage9").transform.FindChild("TimeStep2").transform;
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        s_Switch = GameObject.Find("Stage9").transform.FindChild("Switch").GetComponent<Switch>();
        s_Switch2 = GameObject.Find("Stage9").transform.FindChild("Switch2").GetComponent<Switch>();
        s_Switch3 = GameObject.Find("Stage9").transform.FindChild("Switch3").GetComponent<Switch>();
        s_Switch4 = GameObject.Find("Stage9").transform.FindChild("Switch4").GetComponent<Switch>();
        s_RotateStep = GameObject.Find("Stage9").transform.FindChild("ShortRotateStep").GetComponent<RotateStep>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(3.5f, -32.9f, 0);
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(9, -35.6f, -1);
        s_Ladder.Init();
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_Tower.Init();
        s_RailStep1.Init();
        s_Switch.Init();
        s_Switch2.Init();
        s_Switch3.Init();
        s_Switch4.Init();
        s_RotateStep.Init();

        s_Tower.gameObject.SetActive(false);
        t_TimeStep1.gameObject.SetActive(false);
        t_TimeStep2.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        s_Player.ActivePlayer();
    }

    void Update()
    {
        s_Ove.ActiveOve();
        s_Switch.ActiveSwitch();
        s_Switch2.ActiveSwitch();
        s_Switch3.ActiveSwitch();
        s_Switch4.ActiveSwitch();
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_RotateStep.ActiveRotateStep(s_Switch4);
        s_Ladder.ActiveLadderCheck();
        s_RailStep1.ActiveStep(s_Switch2);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s_Ove.transform.parent = s_Tower.transform.parent;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }

        if (s_Switch4.switchState)
        {
            s_Tower.gameObject.SetActive(true);
        }

        if (s_Switch3.switchState)
        {
            if(!b_IsOnStep1)
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
    }

    IEnumerator DisalbeTimeStep1()
    {
        t_TimeStep1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        t_TimeStep1.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        b_IsOnStep1 = !b_IsOnStep1;
    }

    IEnumerator DisalbeTimeStep2()
    {
        yield return new WaitForSeconds(1.5f);
        t_TimeStep2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        t_TimeStep2.gameObject.SetActive(false);
        b_IsOnStep2 = !b_IsOnStep2;
    }
}
