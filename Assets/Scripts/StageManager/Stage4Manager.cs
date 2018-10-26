using UnityEngine;
using System.Collections;

public class Stage4Manager : MonoBehaviour {
    PlayerControl s_Player;
    Switch s_Switch;
    Switch s_Switch1;
    Tower s_Tower;
    Ove s_Ove;
    StageManager s_StageManager;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    RotateStep s_RotateStep1;
    RotateStep s_RotateStep2;
    Ladder s_Ladder1;
    Ladder s_Ladder2;
    Transform t_LadderCheck1;
    Transform t_LadderCheck2;

    void OnEnable() { Init(); }

    void Awake() { StageClearValue.i_CurStageLevel = 4; }

    void Init()
    {
        s_Player = GameObject.Find("Stage4").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Switch = GameObject.Find("Stage4").transform.FindChild("Switch").GetComponent<Switch>();
        s_Switch1 = GameObject.Find("Stage4").transform.FindChild("Switch1").GetComponent<Switch>();
        s_Tower = GameObject.Find("Stage4").transform.FindChild("Tower").GetComponent<Tower>();
        s_Ove = GameObject.Find("Stage4").transform.FindChild("Ove").GetComponent<Ove>();
        s_Flower1 = GameObject.Find("Stage4").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage4").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage4").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_RotateStep1 = GameObject.Find("Stage4").transform.FindChild("RotateStep1").GetComponent<RotateStep>();
        s_RotateStep2 = GameObject.Find("Stage4").transform.FindChild("RotateStep2").GetComponent<RotateStep>();
        s_Ladder1 = GameObject.Find("Stage4").transform.FindChild("Ladder1").GetComponent<Ladder>();
        s_Ladder2 = GameObject.Find("Stage4").transform.FindChild("Ladder2").GetComponent<Ladder>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        t_LadderCheck1 = GameObject.Find("Stage4").transform.FindChild("LadderCheck1").transform;
        t_LadderCheck2 = GameObject.Find("Stage4").transform.FindChild("LadderCheck2").transform;

        s_Player.Init();
        s_Player.transform.position = new Vector3(4.4f, -36.6f, -1);
        s_Switch.Init();
        s_Switch1.Init();
        s_Tower.Init();
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(16.5f, -40, -2);
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_RotateStep1.Init();
        s_RotateStep2.Init();
        s_Ladder1.Init();
        s_Ladder2.Init();

        s_Ladder1.gameObject.SetActive(false);
        s_Ladder2.gameObject.SetActive(false);
        t_LadderCheck1.gameObject.SetActive(true);
        t_LadderCheck2.gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        s_Player.ActivePlayer();
    }

    void Update()
    {
        if (s_Switch1.switchState)
        {
            s_Ladder1.gameObject.SetActive(true);
            s_Ladder2.gameObject.SetActive(true);
        }

        else
        {
            s_Ladder1.gameObject.SetActive(false);
            s_Ladder2.gameObject.SetActive(false);
        }

        s_Switch.ActiveSwitch();
        s_Switch1.ActiveSwitch();
        s_Ladder1.ActiveLadderCheck();
        s_Ladder2.ActiveLadderCheck();
        s_RotateStep1.ActiveRotateStep(s_Switch1);
        s_RotateStep2.ActiveRotateStep(s_Switch1);
        s_Ove.ActiveOve();
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_Tower.ActiveTower();

        if (s_Switch1.switchState)
        {
            t_LadderCheck1.gameObject.SetActive(false);
            t_LadderCheck2.gameObject.SetActive(false);
        }
        else
        {
            t_LadderCheck1.gameObject.SetActive(true);
            t_LadderCheck2.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s_Ove.transform.parent = s_Tower.transform.parent;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }
    }
}
