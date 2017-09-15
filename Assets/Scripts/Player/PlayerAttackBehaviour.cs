using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{

    private Rigidbody2D Rigid;
    
    private float speed;

    // Use this for initialization
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        //speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rigid.velocity = new Vector2(transform.right.x * speed, Rigid.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            SoundEffectsScript.Instance.MakeEnemyDeathSound();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Caixa")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Substring(0, 4) != "Gato")
            Destroy(gameObject);
    }
    
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
