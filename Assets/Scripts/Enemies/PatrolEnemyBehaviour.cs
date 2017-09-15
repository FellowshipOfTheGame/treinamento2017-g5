using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyBehaviour : MonoBehaviour
{

    private Rigidbody2D Rigid;
    public Transform GroundDetector;
    public Transform WallDetector;
    public LayerMask Solid;

    private float startPosition;
    private bool turned;

    public float speed;
    public float range;
    public int damage;
    public float force;


    // Use this for initialization
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        setStartPosition();
        turned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol ();
    }
    
    void Patrol()
    {
        Rigid.velocity = new Vector2(transform.right.x * speed, Rigid.velocity.y);
        if (Mathf.Abs(transform.position.x - startPosition) >= range || !DetectGround() || DetectWall())
        {
            if (!turned)
            {
                Turn();
                turned = true;
            }
        }
        else
        {
            turned = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Substring(0, 4) == "Gato")
        {
            col.gameObject.GetComponent<AllCatsBehaviour>().Hit(damage);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2)(col.transform.position - transform.position).normalized * force);
        }
    }

    void Turn()
    {
        Rigid.velocity = new Vector2(0f, Rigid.velocity.y);
        transform.Rotate(transform.up, 180f);
    }

    void setStartPosition()
    {
        startPosition = transform.position.x;
    }
    
    bool DetectGround()
    {
        return Physics2D.OverlapCircle((Vector2)GroundDetector.position, 0.2f, Solid);
    }

    bool DetectWall()
    {
        return Physics2D.OverlapCircle((Vector2)WallDetector.position, 0.1f, Solid);
    }
    
    public void Hit()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere((Vector2)GroundDetector.position, 0.2f);
        Gizmos.DrawWireSphere((Vector2)WallDetector.position, 0.1f);

        /*
		Gizmos.color = Color.red;
		Gizmos.DrawLine (new Vector3 (transform.position.x + playerRange/2, transform.position.y + 0.5f), new Vector3 (transform.position.x - playerRange/2, transform.position.y - 0.5f));
		*/
    }
}
