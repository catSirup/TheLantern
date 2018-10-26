using UnityEngine;
using System.Collections;

public class Ove : MonoBehaviour {
    public Sprite Zero;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;

    Transform t_LightFront;
    Transform t_Clear;

    SpriteRenderer spriteRenderer;

    Quaternion q_OriginalRotation;
    private int i_Count;

    public void Init()
    {
        i_Count = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        t_LightFront = GameObject.Find("OveFrontLight").transform;
        t_Clear = gameObject.transform.FindChild("Clear").transform;
        q_OriginalRotation = gameObject.transform.rotation;
        t_Clear.gameObject.SetActive(false);
    }

    public void ActiveOve()
    {
        gameObject.transform.rotation = q_OriginalRotation;
        switch (i_Count)
        {
            case 0:
                spriteRenderer.sprite = Zero;
                t_LightFront.gameObject.light.intensity = 0;
                break;

            case 1:
                spriteRenderer.sprite = One;
                t_LightFront.gameObject.light.intensity = 0.5f;
                break;

            case 2:
                spriteRenderer.sprite = Two;
                t_LightFront.gameObject.light.intensity = 1;
                break;

            case 3:
                spriteRenderer.sprite = Three;
                t_LightFront.gameObject.light.intensity = 1.5f;
                break;
        }

        t_LightFront.transform.parent = t_LightFront.transform;
    }

    public int OveCount
    {
        get { return i_Count; }
        set { i_Count = value; }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Background"))
        {
            gameObject.collider2D.isTrigger = false;
            gameObject.collider2D.enabled = true;
            gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, 2 * gameObject.rigidbody2D.velocity.y);
        }

        if (col.CompareTag("Ground"))
        {
            if (col.rigidbody2D != null)
            {
                Destroy(gameObject.rigidbody2D);
            }
            gameObject.collider2D.isTrigger = false;
            gameObject.collider2D.enabled = true;
        }

        if (col.name == "StepEnd")
        {
            gameObject.collider2D.isTrigger = false;
            gameObject.collider2D.enabled = true;
            gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, 2 * gameObject.rigidbody2D.velocity.y);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.name == "MovingStep1" || coll.gameObject.name == "MovingStep2")
        {
            gameObject.transform.parent = coll.gameObject.transform;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") && coll.gameObject.name != "Box")
        {
            gameObject.collider2D.isTrigger = true;
            Destroy(gameObject.rigidbody2D);
            gameObject.collider2D.enabled = true;
        }

        if (coll.gameObject.CompareTag("Ground") && coll.gameObject.name == "Box")
        {
            gameObject.collider2D.isTrigger = false;
            gameObject.collider2D.enabled = true;
            StartCoroutine(DelayTime());
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.collider2D.isTrigger = true;
    }
}
