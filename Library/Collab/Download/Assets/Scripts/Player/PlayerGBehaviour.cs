using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGBehaviour : MonoBehaviour {

	private Rigidbody2D Rigid;
	private GameObject CS;
    private Animator an;
    private GameObject Atk;
    public GameObject AttackObject;
    public Transform GroundDetector;
    public Transform WallDetector;
	public LayerMask Ground;
    public LayerMask Wall;
    //public CamFollow cam;
    //public BoxCollider2D coll;

    public bool onGround;
    private bool onWall;
    private bool attacking;
    private bool turnedRight;
    private bool isWalking;
    private bool isJumping;

	public float speed;
	public float jumpForce;
    public float groundRay;
    public float wallRay;
    public float attackSpeed;
    private float _time;
    public float attackTime;
    public float attackDelay;

    /*private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();

        cam = GameObject.Find("Main Camera").GetComponent<CamFollow>();
        cam.play = true;
        cam.camArea = new CamFollow.fArea(coll.bounds, cam.FareaSize);
    }
*/
    // Use this for initialization
    void Start () {
		Rigid = GetComponent<Rigidbody2D> ();
		CS = GameObject.FindGameObjectWithTag ("CatSwitch");
        an = GetComponent<Animator>();
        attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Jump ();
        Attack ();

        onGround = Physics2D.OverlapCircle((Vector2)GroundDetector.position, groundRay, Ground);
        onWall = Physics2D.OverlapCircle((Vector2)WallDetector.position, wallRay, Wall);
        turnedRight = (transform.right.x > 0);
        isWalking = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f;

        if (onGround)
            isJumping = false;
    }

	void Move () {
        Rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Rigid.velocity.y);
        if ((Rigid.velocity.x < 0 && turnedRight) || (Rigid.velocity.x > 0 && !turnedRight))
        {
            turnedRight = !turnedRight;
            transform.Rotate(transform.up, 180f);
        }
	}

	void Jump () {
		if (Input.GetKeyDown (KeyCode.UpArrow) && onGround) {
			Rigid.AddForce (transform.up * jumpForce, ForceMode2D.Force);
            isJumping = true;
		}
	}

    void Attack()
    {
        if (gameObject.tag == "GatoBruxo" && Input.GetKeyDown(KeyCode.Space) && _time > attackTime)
        {
            if (Atk != null)
            {
                Destroy(Atk);
            }
            attacking = true;
            an.SetTrigger("Atacando");
            _time = 0f;
        }
        if (attacking)
        {
            _time += Time.deltaTime;
            if (_time >= attackDelay)
            {
                SoundEffectsScript.Instance.MakeBolaEnergiaSound();
                Atk = Instantiate(AttackObject, (Vector3)Rigid.position + transform.up, transform.rotation);
                PlayerAttackBehaviour a = Atk.GetComponent<PlayerAttackBehaviour>();
                a.setSpeed(attackSpeed);
                _time = 0f;
                attacking = false;
            }
        }
        else
        {
            _time += Time.deltaTime;
            if (Atk != null && _time > attackTime)
            {
                Destroy(Atk);
            }
        }
    }

    public void Hit (int damage) {
		CatSwitchScript CSS = CS.GetComponent<CatSwitchScript> ();
		CSS.hp -= damage;
		if (CSS.hp <= 0) {
			Respawn ();
		}
	}

	public void Respawn () {
		transform.position = CS.transform.position;
		Rigid.velocity = Vector2.zero;
		CS.GetComponent<CatSwitchScript> ().resetLife ();
	}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundDetector.position, groundRay);
        Gizmos.DrawWireSphere(WallDetector.position, wallRay);
    }

    // Utilizar essa função somente se for utilizar a mudança de modo de camera, lembrar de consertar o tamanho da camera se isso for feito
    /*void OnTriggerEnter2D (Collider2D col) {
        if (cam.cameraMode)
        {
            cam.switchCameraMode(false, new Vector3(13f, 0f, -10f), 5f);
        }

        else
        {
            cam.switchCameraMode(true, new Vector3(13f, 0f, 0f), 3f);
        }
    }*/
}
