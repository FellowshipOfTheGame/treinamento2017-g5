using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour
{

    private Rigidbody2D Rigid;
    private GameObject Atk;
    private GameObject Player;
    public GameObject AttackObject;
    public LayerMask PlayerLM;
    
    private bool attacked;
    private bool attacking;
    private float _time;
    
    public float playerRange;
    public float attackRate;
    public float attackDur;
    public float attackSpeed;
    public int damage;
    public int touchingDamage;
    public float force;


    // Use this for initialization
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("CatSwitch");
        AttackPosition();
    }
    
    void AttackPosition()
    {
        if (DetectPlayer())
        {
            attacking = true;
            if (transform.right.x * (PlayerPos() - this.transform.position).x < 0f)
            {
                Turn();
            }
            _time += Time.deltaTime;
            if (!attacked && _time > 1 / attackRate)
            {
                Attack();
                _time = 0;
                attacked = true;
            }
            else if (attacked && _time > attackDur)
            {
                Destroy(Atk);
                _time = 0;
                attacked = false;
            }
        }
    }

    void Attack()
    {
        Atk = Instantiate(AttackObject, (Vector3)Rigid.position + transform.up, transform.rotation);
        EnemyAttackBehaviour a = Atk.GetComponent<EnemyAttackBehaviour>();
        a.setDamage(damage);
        a.setForce(force);
        a.setSpeed(attackSpeed);
        SoundEffectsScript.Instance.MakeEnemyAttackSound();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Substring(0, 4) == "Gato")
        {
            col.gameObject.GetComponent<AllCatsBehaviour>().Hit(touchingDamage);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2)(col.transform.position - transform.position).normalized * force);
        }
    }

    void Turn()
    {
        Rigid.velocity = new Vector2(0f, Rigid.velocity.y);
        transform.Rotate(transform.up, 180f);
    }
    
    Vector3 PlayerPos()
    {
        return Player.GetComponent<CatSwitchScript>().Cat.transform.position;
    }
    
    bool DetectPlayer()
    {
        return Physics2D.OverlapArea(new Vector2(transform.position.x + playerRange, transform.position.y + 1.5f), new Vector2(transform.position.x - playerRange, transform.position.y + 0.5f), PlayerLM);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + transform.up, new Vector3(2 * playerRange, 1f));

        /*
		Gizmos.color = Color.red;
		Gizmos.DrawLine (new Vector3 (transform.position.x + playerRange/2, transform.position.y + 0.5f), new Vector3 (transform.position.x - playerRange/2, transform.position.y - 0.5f));
		*/
    }
}
