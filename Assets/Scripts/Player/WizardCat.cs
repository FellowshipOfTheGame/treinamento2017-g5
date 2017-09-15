using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCat : MonoBehaviour {
    
    private GameObject Atk;
    public GameObject AttackObject;

    private bool attacking;
    public float attackSpeed;
    private float _time;
    public float attackTime;
    public float attackDelay;

    void Start()
    {
        attacking = false;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        AllCatsBehaviour allCats = GetComponentInParent<AllCatsBehaviour>();
        if (Input.GetKeyDown(KeyCode.Space) && _time > attackTime && CatSwitchScript.Instance.canBruxoAttack)
        {
            if (Atk != null)
            {
                Destroy(Atk);
            }
            attacking = true;
            allCats.an.SetTrigger("Atacando");
            _time = 0f;
        }
        if (attacking)
        {
            _time += Time.deltaTime;
            if (_time >= attackDelay)
            {
                SoundEffectsScript.Instance.MakeFireCastingSound();
                Atk = Instantiate(AttackObject, (Vector3) allCats.Rigid.position + transform.up, transform.rotation);
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

}
