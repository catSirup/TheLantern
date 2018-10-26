using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    StageManager s_StageManager;
    TopManager s_TopManager;

    void Awake() { Init(); }

    void Init()
    {
        gameObject.SetActive(false);
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        s_TopManager = GameObject.Find("Managers").GetComponent<TopManager>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            if (s_StageManager.stageState == StageManager.StageState.Stage1)
            {
                StageClearValue.isStage1Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage2;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage2)
            {
                StageClearValue.isStage2Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage3;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage3)
            {
                StageClearValue.isStage3Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage4;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage4)
            {
                StageClearValue.isStage4Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage5;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage5)
            {
                StageClearValue.isStage5Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage6;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage6)
            {
                StageClearValue.isStage6Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage7;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage7)
            {
                StageClearValue.isStage7Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage8;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage8)
            {
                StageClearValue.isStage8Clear = true;
                s_StageManager.stageState = StageManager.StageState.Stage9;
            }

            else if (s_StageManager.stageState == StageManager.StageState.Stage9)
            {
                StageClearValue.isStage9Clear = true;
                s_TopManager.curState = TopManager.ManagerActiveState.EPILOGUE;
            }
        }
    }
}
