using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("_anim is null!!!!!!!!!!");
        }
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        if( _swordAnim == null)
        {
            Debug.LogError("_swordAnim is null!!!!!!");
        }
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool isJumping)
    {
        _anim.SetBool("Jumping", isJumping);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attacking");
        _swordAnim.SetTrigger("Sword_Animation");
    }
}
