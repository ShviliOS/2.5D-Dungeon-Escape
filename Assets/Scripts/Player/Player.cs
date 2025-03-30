using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    private Rigidbody2D _rb2D;
    private float _xDir;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _jumpHeight = 5;
    [SerializeField]
    private bool _resetJump;
    [SerializeField]
    private bool _isGrounded;
    private PlayerAnimation _playerAnim;

    public int Health { get; set; }

    //private SpriteRenderer _childSR;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        if (_rb2D == null)
        {
            Debug.LogError("_rb2D is null!!!!!!");
        }
        _playerAnim = GetComponent<PlayerAnimation>();
        if (_playerAnim == null)
        {
            Debug.LogError("_playerAnim is null!!!!!!!!!");
        }

        Health = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isGrounded)
        {
            Debug.Log("attacking");
            _playerAnim.Attack();
        }
    }

    void Movement()
    {
        _isGrounded = IsGrounded();
        _xDir = Input.GetAxisRaw("Horizontal");
        if (_xDir > 0)
        {
            Flip(true);
        }
        else if (_xDir < 0)
        {
           Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerAnim.Jump(true);
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpHeight);
            StartCoroutine(ResetJumpRoutine());
        }
        _rb2D.velocity = new Vector2(_xDir * _speed, _rb2D.velocity.y);
        _playerAnim.Move(_xDir);
    }



    void Flip(bool facingRight)
    {
        if (facingRight)
        {
            transform.localScale = new Vector2(_xDir, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(_xDir, transform.localScale.y);
        }
    }


    bool IsGrounded()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << 6);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hit2D.collider != null)
        {
            if (!_resetJump)
            {
                
                _playerAnim.Jump(false);
                return true;
            }
        }

        return false;

    }
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        print(" Player: Damage()");
    }

    
}
