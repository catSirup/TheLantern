using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public AudioClip a_JumpSound;
    public AudioClip a_ThrowSound;

    private float f_MoveForce;
    private float f_JumpForce;
    private float f_ThrowForce;
    private Vector2 v2_OriginalPosition;

    private float f_InputX;
    private float f_InputY;

    private Transform t_Stage;

    // 사다리 관련 변수
    private bool b_IsUpDownLadder;
    private bool b_IsCanLadder;
    private bool b_IsGround;

    // 점프 관련 변수
    private bool b_IsCanJump;
    private bool b_IsJumping;

    // 오브 관련 변수
    private bool b_IsHaveOve;

    private bool b_IsSeeRight;

    private Vector2 gapVector;

    private int i_LanternCount;

    Transform t_Light;
    Transform t_BackLight;
    Transform t_Ove;
    Switch s_Switch;
    Ove s_Ove;
    Tower s_Tower;
    TopManager s_TopManager;
    StageManager s_StageManager;

    Animator animator;

    public void Init()
    {
        f_MoveForce = 5.0f;
        f_ThrowForce = 40.0f;
        f_JumpForce = 100.0f;
        b_IsUpDownLadder = false;
        b_IsCanLadder = false;
        b_IsCanJump = false;
        b_IsJumping = false;
        b_IsHaveOve = false;
        i_LanternCount = 0;
        b_IsSeeRight = true;
        b_IsGround = false;
        gapVector = new Vector2(0, 0);

        gameObject.rigidbody2D.velocity = new Vector2(0, 0);
        s_Switch = GameObject.Find("Switch").GetComponent<Switch>();
        t_Light = gameObject.transform.FindChild("PlayerLight").transform;
        t_BackLight = gameObject.transform.FindChild("PlayerBackLight").transform;
        t_Ove = GameObject.Find("Ove").transform;
        animator = gameObject.GetComponent<Animator>();
        s_Tower = GameObject.Find("Stage" + StageClearValue.i_CurStageLevel.ToString()).transform.FindChild("Tower").GetComponent<Tower>();
        s_Ove = GameObject.Find("Ove").GetComponent<Ove>();
        s_TopManager = GameObject.Find("Managers").GetComponent<TopManager>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        t_Stage = GameObject.Find("Stage" + StageClearValue.i_CurStageLevel.ToString()).transform;
    }

    public void ActivePlayer()
    {
        f_InputX = Input.GetAxis("Horizontal");
        f_InputY = Input.GetAxis("Vertical");

        AnimationSetting();
        LightSetting();
        Move();
        Jump();
        Ladder();
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(0.3f);
        b_IsJumping = false;
    }

    void LightSetting()
    {
        t_Light.transform.parent = gameObject.transform;

        switch (i_LanternCount)
        {
            case 0:
                if (!b_IsHaveOve || (b_IsHaveOve && s_Ove.OveCount == 0))
                {
                    t_Light.gameObject.light.intensity = 0.2f;
                    t_BackLight.gameObject.light.intensity = 0.2f;
                }

                else
                {
                    t_Light.gameObject.light.intensity = 1.0f;
                    t_BackLight.gameObject.light.intensity = 1.0f;
                }
                break;

            case 1:
                t_Light.gameObject.light.intensity = 0.5f;
                t_BackLight.gameObject.light.intensity = 0.5f;
                break;

            case 2:
                t_Light.gameObject.light.intensity = 1.0f;
                t_BackLight.gameObject.light.intensity = 1.0f;
                break;

            case 3:
                t_Light.gameObject.light.intensity = 1.5f;
                t_BackLight.gameObject.light.intensity = 1.5f;
                break;
        }
    }

    void AnimationSetting()
    {
        animator.SetFloat("f_InputX", f_InputX);
        animator.SetFloat("f_InputY", f_InputY);
        animator.SetBool("b_IsJumping", b_IsJumping);
        animator.SetBool("b_IsCanJump", b_IsCanJump);
        animator.SetBool("b_IsUpDownLadder", b_IsUpDownLadder);
        animator.SetBool("b_IsCanLadder", b_IsCanLadder);
        animator.SetBool("b_IsHaveOve", b_IsHaveOve);
        animator.SetBool("b_IsGround", b_IsGround);
    }

    void Move()
    {
        if (Mathf.Abs(f_InputX) > 0)
        {
            b_IsUpDownLadder = false;
            gameObject.rigidbody2D.gravityScale = 3.5f;
            b_IsSeeRight = Mathf.Sign(f_InputX) == 1 ? true : false;

            Quaternion q_RotationCharacter = transform.rotation;
            transform.rotation = Quaternion.Euler(q_RotationCharacter.x, Mathf.Sign(f_InputX) == 1 ? 0 : 180, q_RotationCharacter.z);
            gameObject.rigidbody2D.velocity = new Vector2(f_InputX * f_MoveForce * Time.deltaTime * 100, rigidbody2D.velocity.y);
        }

        else
            gameObject.rigidbody2D.velocity = new Vector2(0, gameObject.rigidbody2D.velocity.y);
    }

    void Jump()
    {
        if (b_IsCanJump && Input.GetKeyDown(KeyCode.Space))
        {
            b_IsJumping = true;
            AudioSource.PlayClipAtPoint(a_JumpSound, gameObject.transform.position);
            b_IsCanJump = false;
        }

        if (b_IsJumping)
        {
            gameObject.rigidbody2D.AddForce(Vector2.up * f_JumpForce);
            StartCoroutine(FallDelay());
        }
    }

    void Ladder()
    {
        if (b_IsUpDownLadder)
        {
            gameObject.rigidbody2D.gravityScale = 0.0f;
            gameObject.rigidbody2D.velocity = new Vector2(0,
                                                                    f_InputY * f_MoveForce * Time.deltaTime * 100);
        }

        else
        {
            gameObject.rigidbody2D.gravityScale = 3.5f;
        }

        //Debug.Log("b_IsUpDownLadder : " + b_IsUpDownLadder + " + b_IsCanLadder : " + b_IsCanLadder);
    }

    /// <summary>
    /// 오브 투척
    /// </summary>
    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && b_IsHaveOve)
        {
            gapVector = (gameObject.transform.position * 10 - Input.mousePosition);

            if (b_IsSeeRight)
            {
                if (gapVector.x <= 0)
                    gapVector = new Vector2(0, 0);
            }

            else
            {
                if (gapVector.x > 0)
                    gapVector = new Vector2(0, 0);
            }
        }
    }

    void OnMouseUp()
    {
        if (b_IsHaveOve)
        {
            t_Ove.transform.parent = t_Stage.transform;
            AudioSource.PlayClipAtPoint(a_ThrowSound, gameObject.transform.position);
               
            if (t_Ove.gameObject.rigidbody2D == null)
            {
                t_Ove.gameObject.AddComponent<Rigidbody2D>();
                t_Ove.rigidbody2D.gravityScale = 3.5f;
            }
            t_Ove.collider2D.enabled = true;
            t_Ove.rigidbody2D.velocity = new Vector2(gapVector.normalized.x * f_ThrowForce, -gapVector.normalized.y * f_ThrowForce / 2.5f);
            b_IsHaveOve = false;
        }
    }

    /// <summary>
    /// property
    /// </summary>
    public int LanternCount
    {
        get { return i_LanternCount; }
        set { i_LanternCount = value; }
    }

    public bool HaveOve
    {
        get { return b_IsHaveOve; }
        set { b_IsHaveOve = value; }
    }

    public bool CanLadder
    {
        get { return b_IsCanLadder; }
        set { b_IsCanLadder = value; }
    }

    public bool UpDownLadder
    {
        get { return b_IsUpDownLadder; }
        set { b_IsUpDownLadder = value; }
    }

    public float InputY
    {
        get { return f_InputY; }
        set { f_InputY = value; }
    }

    public bool CanJump
    {
        get { return b_IsCanJump; }
        set { b_IsCanJump = value; }
    }

    public bool IsGround
    {
        get { return b_IsGround; }
        set { b_IsGround = value; }
    }

    /// <summary>
    /// 충돌 체크
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        // 오브
        if (col.CompareTag("Ove") && !s_Tower.Attach)
        {
            s_Ove.OveCount += i_LanternCount;
            i_LanternCount = 0;

            if (Input.GetKeyDown(KeyCode.E))
            {
                b_IsHaveOve = true;
                col.transform.parent = gameObject.transform;

                if (b_IsSeeRight)
                    col.transform.position = new Vector2(gameObject.transform.position.x + 3.5f, gameObject.transform.position.y);
                else
                    col.transform.position = new Vector2(gameObject.transform.position.x - 3.5f, gameObject.transform.position.y);

                col.enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            b_IsCanJump = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            b_IsCanJump = true;
        }

        if (coll.gameObject.name == "StepEnd")
        {
            b_IsCanJump = false;
            gameObject.rigidbody2D.velocity = new Vector2(0, gameObject.rigidbody2D.velocity.y);
        }

        if (coll.gameObject.CompareTag("DeadLine"))
        {
            //s_StageManager.stageState = StageManager.StageState.Stage0;
            s_TopManager.curState = TopManager.ManagerActiveState.ENDING;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            b_IsCanJump = false;
        }
    }
}
