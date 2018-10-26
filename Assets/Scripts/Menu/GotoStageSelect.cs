using UnityEngine;
using System.Collections;

public class GotoStageSelect : MonoBehaviour {
    StageManager s_StageManager;
    TopManager s_TopManager;
	void Start () {
        s_StageManager = GameObject.Find("Managers").transform.FindChild("Stage").GetComponent<StageManager>();
        s_TopManager = GameObject.Find("Managers").GetComponent<TopManager>();
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            s_TopManager.curState = TopManager.ManagerActiveState.STAGE;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }
	}
}
