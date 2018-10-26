using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    Transform t_StageSelect;
    Transform t_StageImage;
    Transform t_Stage1_Select;
    Transform t_Stage2_Select;
    Transform t_Stage3_Select;
    Transform t_Stage4_Select;
    Transform t_Stage5_Select;
    Transform t_Stage6_Select;
    Transform t_Stage7_Select;
    Transform t_Stage8_Select;
    Transform t_Stage9_Select;

    Transform t_Stage1;
    Transform t_Stage2;
    Transform t_Stage3;
    Transform t_Stage4;
    Transform t_Stage5;
    Transform t_Stage6;
    Transform t_Stage7;
    Transform t_Stage8;
    Transform t_Stage9;

    Transform t_Back;
    Transform t_CheckBox;

    public enum StageState
    {
        Stage0, Stage1, Stage2, Stage3, Stage4, Stage5, Stage6, Stage7, Stage8, Stage9 ,SelectCheck
    };

    private StageState curState;

    void Awake() { Init(); }

    void Update() { ActiveStage(); }

    void Init()
    {
        t_StageSelect = GameObject.Find("StageSelectManager").transform.FindChild("StageSelect").transform;
        t_StageImage = GameObject.Find("StageSelectManager").transform.FindChild("StageImage").transform;
        t_Stage1_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage1_Select").transform;
        t_Stage2_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage2_Select").transform;
        t_Stage3_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage3_Select").transform;
        t_Stage4_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage4_Select").transform;
        t_Stage5_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage5_Select").transform;
        t_Stage6_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage6_Select").transform;
        t_Stage7_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage7_Select").transform;
        t_Stage8_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage8_Select").transform;
        t_Stage9_Select = GameObject.Find("StageSelectManager").transform.FindChild("Stage9_Select").transform;

        t_Stage1 = GameObject.Find("StageSelectManager").transform.FindChild("Stage1_Select").transform.FindChild("Stage1").transform;
        t_Stage2 = GameObject.Find("StageSelectManager").transform.FindChild("Stage2_Select").transform.FindChild("Stage2").transform;
        t_Stage3 = GameObject.Find("StageSelectManager").transform.FindChild("Stage3_Select").transform.FindChild("Stage3").transform;
        t_Stage4 = GameObject.Find("StageSelectManager").transform.FindChild("Stage4_Select").transform.FindChild("Stage4").transform;
        t_Stage5 = GameObject.Find("StageSelectManager").transform.FindChild("Stage5_Select").transform.FindChild("Stage5").transform;
        t_Stage6 = GameObject.Find("StageSelectManager").transform.FindChild("Stage6_Select").transform.FindChild("Stage6").transform;
        t_Stage7 = GameObject.Find("StageSelectManager").transform.FindChild("Stage7_Select").transform.FindChild("Stage7").transform;
        t_Stage8 = GameObject.Find("StageSelectManager").transform.FindChild("Stage8_Select").transform.FindChild("Stage8").transform;
        t_Stage9 = GameObject.Find("StageSelectManager").transform.FindChild("Stage9_Select").transform.FindChild("Stage9").transform;

        t_Back = GameObject.Find("StageSelectManager").transform.FindChild("Back").transform;
        t_CheckBox = GameObject.Find("StageSelectManager").transform.FindChild("Check").transform;

        curState = StageState.Stage0;
    }

    void ActiveStage()
    {
        switch (curState)
        {
            case StageState.Stage0:
                t_StageSelect.gameObject.SetActive(true);
                t_StageImage.gameObject.SetActive(true);
                t_Stage1_Select.gameObject.SetActive(true);
                t_Stage2_Select.gameObject.SetActive(true);
                t_Stage3_Select.gameObject.SetActive(true);
                t_Stage4_Select.gameObject.SetActive(true);
                t_Stage5_Select.gameObject.SetActive(true);
                t_Stage6_Select.gameObject.SetActive(true);
                t_Stage7_Select.gameObject.SetActive(true);
                t_Stage8_Select.gameObject.SetActive(true);
                t_Stage9_Select.gameObject.SetActive(true);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(true);
                t_CheckBox.gameObject.SetActive(false);

                t_Stage1_Select.gameObject.renderer.enabled = true;
                t_Stage2_Select.gameObject.renderer.enabled = true;
                t_Stage3_Select.gameObject.renderer.enabled = true;
                t_Stage4_Select.gameObject.renderer.enabled = true;
                t_Stage5_Select.gameObject.renderer.enabled = true;
                t_Stage6_Select.gameObject.renderer.enabled = true;
                t_Stage7_Select.gameObject.renderer.enabled = true;
                t_Stage8_Select.gameObject.renderer.enabled = true;
                t_Stage9_Select.gameObject.renderer.enabled = true;

                t_Stage1_Select.gameObject.collider2D.enabled = true;
                t_Stage2_Select.gameObject.collider2D.enabled = true;
                t_Stage3_Select.gameObject.collider2D.enabled = true;
                t_Stage4_Select.gameObject.collider2D.enabled = true;
                t_Stage5_Select.gameObject.collider2D.enabled = true;
                t_Stage6_Select.gameObject.collider2D.enabled = true;
                t_Stage7_Select.gameObject.collider2D.enabled = true;
                t_Stage8_Select.gameObject.collider2D.enabled = true;
                t_Stage9_Select.gameObject.collider2D.enabled = true;

                // 체크박스가 꺼져 있을 때 다른 메뉴를 선택할 수 있도록 컬라이더 활성화
                t_StageImage.gameObject.collider2D.enabled = true;
                t_Stage1_Select.gameObject.collider2D.enabled = true;
                t_Stage2_Select.gameObject.collider2D.enabled = true;
                t_Stage3_Select.gameObject.collider2D.enabled = true;
                t_Stage4_Select.gameObject.collider2D.enabled = true;
                t_Stage5_Select.gameObject.collider2D.enabled = true;
                t_Stage6_Select.gameObject.collider2D.enabled = true;
                t_Stage7_Select.gameObject.collider2D.enabled = true;
                t_Stage8_Select.gameObject.collider2D.enabled = true;
                t_Stage9_Select.gameObject.collider2D.enabled = true;
                break;

            case StageState.Stage1:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                //----- Stage1_Select 스프라이트와 컬라이더 off -----
                t_Stage1_Select.gameObject.renderer.enabled = false;
                t_Stage1_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(true);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage2:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(true);
                //----- Stage2_Select 스프라이트와 컬라이더 off -----
                t_Stage2_Select.gameObject.renderer.enabled = false;
                t_Stage2_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(true);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage3:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(true);
                //----- Stage3_Select 스프라이트와 컬라이더 off -----
                t_Stage3_Select.gameObject.renderer.enabled = false;
                t_Stage3_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(true);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;


            case StageState.Stage4:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(true);
                //----- Stage4_Select 스프라이트와 컬라이더 off -----
                t_Stage4_Select.gameObject.renderer.enabled = false;
                t_Stage4_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(true);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;


            case StageState.Stage5:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(true);
                //----- Stage5_Select 스프라이트와 컬라이더 off -----
                t_Stage5_Select.gameObject.renderer.enabled = false;
                t_Stage5_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(true);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage6:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(true);
                //----- Stage6_Select 스프라이트와 컬라이더 off -----
                t_Stage6_Select.gameObject.renderer.enabled = false;
                t_Stage6_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(true);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage7:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(true);
                //----- Stage7_Select 스프라이트와 컬라이더 off -----
                t_Stage7_Select.gameObject.renderer.enabled = false;
                t_Stage7_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(true);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage8:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(true);
                //----- Stage8_Select 스프라이트와 컬라이더 off -----
                t_Stage8_Select.gameObject.renderer.enabled = false;
                t_Stage8_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------
                t_Stage9_Select.gameObject.SetActive(false);

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(true);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.Stage9:
                t_StageSelect.gameObject.SetActive(false);
                t_StageImage.gameObject.SetActive(false);
                t_Stage1_Select.gameObject.SetActive(false);
                t_Stage2_Select.gameObject.SetActive(false);
                t_Stage3_Select.gameObject.SetActive(false);
                t_Stage4_Select.gameObject.SetActive(false);
                t_Stage5_Select.gameObject.SetActive(false);
                t_Stage6_Select.gameObject.SetActive(false);
                t_Stage7_Select.gameObject.SetActive(false);
                t_Stage8_Select.gameObject.SetActive(false);
                t_Stage9_Select.gameObject.SetActive(true);
                //----- Stage9_Select 스프라이트와 컬라이더 off -----
                t_Stage9_Select.gameObject.renderer.enabled = false;
                t_Stage9_Select.gameObject.collider2D.enabled = false;
                //---------------------------------------------------

                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(true);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(false);
                break;

            case StageState.SelectCheck:
                t_StageSelect.gameObject.SetActive(true);
                t_StageImage.gameObject.SetActive(true);
                t_Stage1_Select.gameObject.SetActive(true);
                t_Stage2_Select.gameObject.SetActive(true);
                t_Stage3_Select.gameObject.SetActive(true);
                t_Stage4_Select.gameObject.SetActive(true);
                t_Stage5_Select.gameObject.SetActive(true);
                t_Stage6_Select.gameObject.SetActive(true);
                t_Stage7_Select.gameObject.SetActive(true);
                t_Stage8_Select.gameObject.SetActive(true);
                t_Stage9_Select.gameObject.SetActive(true);
                t_Stage1.gameObject.SetActive(false);
                t_Stage2.gameObject.SetActive(false);
                t_Stage3.gameObject.SetActive(false);
                t_Stage4.gameObject.SetActive(false);
                t_Stage5.gameObject.SetActive(false);
                t_Stage6.gameObject.SetActive(false);
                t_Stage7.gameObject.SetActive(false);
                t_Stage8.gameObject.SetActive(false);
                t_Stage9.gameObject.SetActive(false);

                t_Back.gameObject.SetActive(false);
                t_CheckBox.gameObject.SetActive(true);
                // 체크박스가 켜져 있을 때 다른 메뉴를 선택하지 못하도록 컬라이더 비활성화
                t_StageImage.gameObject.collider2D.enabled = false;
                t_Stage1_Select.gameObject.collider2D.enabled = false;
                t_Stage2_Select.gameObject.collider2D.enabled = false;
                t_Stage3_Select.gameObject.collider2D.enabled = false;
                t_Stage4_Select.gameObject.collider2D.enabled = false;
                t_Stage5_Select.gameObject.collider2D.enabled = false;
                t_Stage6_Select.gameObject.collider2D.enabled = false;
                t_Stage7_Select.gameObject.collider2D.enabled = false;
                t_Stage8_Select.gameObject.collider2D.enabled = false;
                t_Stage9_Select.gameObject.collider2D.enabled = false;
                break;
        }
    }

    public StageState stageState
    {
        get { return curState; }
        set { curState = value; }
    }
}

