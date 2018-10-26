using UnityEngine;
using System.Collections;

public class Stage6Manager : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Tower s_Tower;
    Switch s_Switch;
    Switch s_Switch1;
    Ladder s_Ladder;
    StageManager s_StageManager;
    RotateStep s_RotateStep1;
    RotateStep s_RotateStep2;
    RotateStep s_RotateStep3;

    void OnEnable()
    {
        Init();
    }

    void Awake()
    {
        StageClearValue.i_CurStageLevel = 6;
    }

    void Update()
    {
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);

        s_Ove.ActiveOve();
        s_Switch.ActiveSwitch();
        s_Switch1.ActiveSwitch();
        s_RotateStep1.ActiveRotateStep(s_Switch1);
        s_RotateStep2.ActiveRotateStep(s_Switch1);
        s_RotateStep3.ActiveRotateStep(s_Switch1);
        s_Ladder.ActiveLadderCheck();
        s_Tower.ActiveTower();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s_Ove.transform.parent = s_Tower.transform.parent;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }
    }

    void FixedUpdate()
    {
        s_Player.ActivePlayer();
    }

    void Init()
    {
        s_Player = GameObject.Find("Stage6").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Ove = GameObject.Find("Stage6").transform.FindChild("Ove").GetComponent<Ove>();
        s_Flower1 = GameObject.Find("Stage6").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage6").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage6").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_Tower = GameObject.Find("Stage6").transform.FindChild("Tower").GetComponent<Tower>();
        s_Switch1 = GameObject.Find("Stage6").transform.FindChild("Switch1").GetComponent<Switch>();
        s_Switch = GameObject.Find("Stage6").transform.FindChild("Switch").GetComponent<Switch>();
        s_RotateStep1 = GameObject.Find("Stage6").transform.FindChild("RotateStep1").GetComponent<RotateStep>();
        s_RotateStep2 = GameObject.Find("Stage6").transform.FindChild("RotateStep2").GetComponent<RotateStep>();
        s_RotateStep3 = GameObject.Find("Stage6").transform.FindChild("RotateStep3").GetComponent<RotateStep>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        s_Ladder = GameObject.Find("Stage6").transform.FindChild("Ladder").GetComponent<Ladder>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(5.1f, -28.5f, 0);
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(17, -32.1f, -1);
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_Tower.Init();
        s_Switch.Init();
        s_Switch1.Init();
        s_Ladder.Init();
        s_RotateStep1.Init();
        s_RotateStep2.Init();
        s_RotateStep3.Init();
    }
}
