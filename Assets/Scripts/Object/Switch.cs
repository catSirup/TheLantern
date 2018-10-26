using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public Sprite s_SwitchOff;
    public Sprite s_SwitchOn;

    private bool curState;
    private SpriteRenderer spriteRenderer;

    public void Init()
    {
        curState = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ActiveSwitch()
    {
        switch (curState)
        {
            case true:
                spriteRenderer.sprite = s_SwitchOn;
                break;

            case false:
                spriteRenderer.sprite = s_SwitchOff;
                break;
        }
    }

    public bool switchState
    {
        get { return this.curState; }
        set { this.curState = value; }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Box")
        {
            if(gameObject.CompareTag("Ground"))
            {
                this.curState = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Box")
        {
            if (gameObject.CompareTag("Ground"))
            {
                this.curState = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // 스위치
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.curState = !this.curState;
            }
        }
    }
}
