using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField, Range(0f, 1f)]
    private float m_Deceleration;

    [SerializeField]
    private float m_MoveSpeed, m_JumpForce, m_StompForce;


    private float _dir = 0;

    private bool _isGrounded = false;

    private bool _isJumping = false;

    private bool _wannaStomp = false;
    private bool _isStomping = false;

    [SerializeField]
    private LayerMask m_GroundMask;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move(float dir)
    {
        _dir = dir;
    }

    public void Jump()
    {
        if(_isGrounded)
            _isJumping = true;
    }

    public void Stomp()
    {
        if (!_isGrounded && !_isStomping)
        {
            _wannaStomp = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_dir) > 0.01f)
        {
            _rigidBody.velocity = new Vector2(_dir * m_MoveSpeed, _rigidBody.velocity.y);
        } else
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x * m_Deceleration, _rigidBody.velocity.y);
        }

        if (_isJumping)
        {
            _isJumping = false;

            _rigidBody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }

        if (_wannaStomp)
        {
            _wannaStomp = false;
            _isStomping = true;

            _rigidBody.AddForce(Vector2.down * m_StompForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, m_GroundMask);

        if (_isStomping)
        {
            _isStomping = !_isGrounded;
        }
    }

    public bool IsStomping()
    {
        return _isStomping;
    }
}
