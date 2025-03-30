using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    private GameObject _acidPrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {

    }
    public void Damage()
    {
        if (isDead) return;
        Health--;
        if(Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            Destroy(gameObject, 3);
        }
    }

    public override void Movement()
    {
        
    }

    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);  
    }
}
