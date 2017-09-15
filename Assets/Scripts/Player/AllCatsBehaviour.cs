using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCatsBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D Rigid;
    [HideInInspector]
    public Animator an;
    public Transform GroundDetector;
    public Transform WallDetector;
    public LayerMask Solid;
    public LayerMask Water;
    
    [HideInInspector]
    public bool onGround;
    [HideInInspector]
    public bool onWall;
    private bool onWater;
    private bool turnedRight;
    private bool isWalking;
    private bool isJumping;
    [HideInInspector]
    public int jumpCounter;

    public float invincibleTime = 1;
    public int maxJumps;
    public float speed;
    public float jumpForce;
    public float groundRay;
    public float wallRay;
    
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Jump();

        onGround = Physics2D.OverlapCircle((Vector2)GroundDetector.position, groundRay, Solid);
        onWall = Physics2D.OverlapCircle((Vector2)WallDetector.position, wallRay, Solid);
        onWater = Physics2D.OverlapCircle((Vector2)GroundDetector.position, groundRay, Water);
        turnedRight = (transform.right.x > 0);
        isWalking = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f;
             
        if (onWater)
        {
            jumpCounter = 0;
        }
        else if (onWall && !onGround)
        {
            jumpCounter = 1;
        }
        else if (onGround && Rigid.velocity.y < 0f)
        {
            isJumping = false;
            jumpCounter = 0;
        }

        Animations();
    }

    void Move()
    {
        if (!onWall)
            Rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Rigid.velocity.y);
        if ((Input.GetAxis("Horizontal") < 0 && turnedRight) || (Input.GetAxis("Horizontal") > 0 && !turnedRight))
        {
            turnedRight = !turnedRight;
            transform.Rotate(transform.up, 180f);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (jumpCounter < maxJumps) && !onWall)
        {
            jumpCounter++;
            Rigid.velocity = Vector2.zero;
            Rigid.AddForce(transform.up * jumpForce);
        }
    }
    
    public void Hit(int damage)
    {
        CatSwitchScript.Instance.hp -= damage;
        if (CatSwitchScript.Instance.hp <= 0)
        {
            SoundEffectsScript.Instance.MakeDeathSound();
            CatSwitchScript.Instance.Resp();
        }
        else
        {
            StartCoroutine(HurtBlinker());
        }
    }
    
    IEnumerator HurtBlinker()
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        an.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(invincibleTime);

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);

        an.SetLayerWeight(1, 0);
    }
    
    void Animations()
    {
        an.SetBool("Andando", (onGround && isWalking));
        if (tag != "GatoEgipcio")
        {
            an.SetBool("Pulando", !onGround);
            if (tag != "GatoNinja")
            {
                an.SetFloat("VelVertical", Rigid.velocity.y);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundDetector.position, groundRay);
        Gizmos.DrawWireSphere(WallDetector.position, wallRay);
    }
}
