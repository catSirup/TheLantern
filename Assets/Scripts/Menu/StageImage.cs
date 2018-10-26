using UnityEngine;
using System.Collections;

public class StageImage : MonoBehaviour {
    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    public Sprite Stage4;
    public Sprite Stage5;
    public Sprite Stage6;
    public Sprite Stage7;
    public Sprite Stage8;
    public Sprite Stage9;

    SpriteRenderer spriteRenderer;
    StageManager s_StageManager;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        spriteRenderer.sprite = Stage1;
    }

    void Update()
    {
        if (StageSelect.b_Stage1)
        {
            spriteRenderer.sprite = Stage1;
        }

        else if (StageSelect.b_Stage2)
        {
            spriteRenderer.sprite = Stage2;
        }

        else if (StageSelect.b_Stage3)
        {
            spriteRenderer.sprite = Stage3;
        }

        else if (StageSelect.b_Stage4)
        {
            spriteRenderer.sprite = Stage4;
        }

        else if (StageSelect.b_Stage5)
        {
            spriteRenderer.sprite = Stage5;
        }

        else if (StageSelect.b_Stage6)
        {
            spriteRenderer.sprite = Stage6;
        }

        else if (StageSelect.b_Stage7)
        {
            spriteRenderer.sprite = Stage7;
        }

        else if (StageSelect.b_Stage8)
        {
            spriteRenderer.sprite = Stage8;
        }

        else if (StageSelect.b_Stage9)
        {
            spriteRenderer.sprite = Stage9;
        }
    }

    void OnMouseDown()
    {
        if (gameObject.name == "StageImage")
        {
            s_StageManager.stageState = StageManager.StageState.SelectCheck;

            if (spriteRenderer.sprite == Stage1)
            {
                StageSelect.b_Stage1 = true;
            }

            else if (spriteRenderer.sprite == Stage2)
            {
                StageSelect.b_Stage2 = true;
            }

            else if (spriteRenderer.sprite == Stage3)
            {
                StageSelect.b_Stage3 = true;
            }

            else if (spriteRenderer.sprite == Stage4)
            {
                StageSelect.b_Stage4 = true;
            }

            else if (spriteRenderer.sprite == Stage5)
            {
                StageSelect.b_Stage5 = true;
            }

            else if (spriteRenderer.sprite == Stage6)
            {
                StageSelect.b_Stage6 = true;
            }

            else if (spriteRenderer.sprite == Stage7)
            {
                StageSelect.b_Stage7 = true;
            }

            else if (spriteRenderer.sprite == Stage8)
            {
                StageSelect.b_Stage8 = true;
            }

            else if (spriteRenderer.sprite == Stage9)
            {
                StageSelect.b_Stage9 = true;
            }
        }
    }
}
