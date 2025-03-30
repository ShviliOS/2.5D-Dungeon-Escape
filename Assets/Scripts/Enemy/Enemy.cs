using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform _pointA, _pointB;

    protected Vector3 targetPosition;
    protected Animator anim;
    protected SpriteRenderer sR;

    protected bool isHit = false;
    protected Transform playerPos;

    protected bool isDead;

    [SerializeField]
    protected GameObject diamondPrefab;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sR = GetComponentInChildren<SpriteRenderer>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (!isDead)
        {
            Movement();
        }
        

    }
    public virtual void Movement()
    {
        if (targetPosition == _pointA.position)
        {
            sR.flipX = true;
        }
        else if (targetPosition == _pointB.position)
        {
            sR.flipX = false;
        }

        if (transform.position == _pointA.position)
        {
            targetPosition = _pointB.position;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == _pointB.position)
        {
            targetPosition = _pointA.position;
            anim.SetTrigger("Idle");
        }

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.position, playerPos.position);
        if (distance > 2)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        Vector3 direction = playerPos.position - transform.position;

        if (direction.x > 0 && anim.GetBool("InCombat"))
        {
            sR.flipX = false;
        }
        else if (direction.x < 1 && anim.GetBool("InCombat"))
        {
            sR.flipX = true;
        }
    }
}
