using UnityEngine;
using System.Collections;

public class Stage8Manager : MonoBehaviour {
    PlayerControl s_Player;
    Tower s_Tower;
    Ove s_Ove;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Switch s_Switch;
    Switch s_Switch1;
    RailStep s_RailStep;
    StageManager s_StageManager;

    void OnEnable() { Init(); }

    void Awake() { StageClearValue.i_CurStageLevel = 8; }

    void Init()
    {
        s_Player = GameObject.Find("Stage8").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Tower = GameObject.Find("Stage8").transform.FindChild("Tower").GetComponent<Tower>();
        s_Ove = GameObject.Find("Stage8").transform.FindChild("Ove").GetComponent<Ove>();
        s_Flower1 = GameObject.Find("Stage8").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage8").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage8").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_Switch = GameObject.Find("Stage8").transform.FindChild("Switch").GetComponent<Switch>();
        s_Switch1 = GameObject.Find("Stage8").transform.FindChild("Switch2").GetComponent<Switch>();
        s_RailStep = GameObject.Find("Stage8").transform.FindChild("RailStep").GetComponent<RailStep>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(3.6f, -33.3f, 0);
        s_Tower.Init();
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(16, -35.8f, -1);
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_Switch.Init();
        s_Switch1.Init();
        s_RailStep.Init();
    }

    void Update()
    {
        s_Switch1.ActiveSwitch();
        s_Switch.ActiveSwitch();
        s_Ove.ActiveOve();
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_RailStep.ActiveStep(s_Switch1);
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
}
