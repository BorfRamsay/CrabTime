using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    private Rigidbody2D _rb2d;

    public float speed;
    public float jumpForce = 10.0f;
    private float moveInput;
    

    private bool _isFlipped = false;
    private float _groundDistance = 1.2f;
    private bool _isGrounded = false;
    private float _floatForce = 10.0f;
    private float _floatTimer = 3.0f;
    private Animator _ani;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButton("Jump") && _isGrounded)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
        }
        else if (Input.GetButton("Jump") && _rb2d.velocity.y < 0 && _floatTimer > 0)
        {
            _floatTimer -= Time.deltaTime;
            _rb2d.AddForce(Vector2.up * _floatForce, ForceMode2D.Force);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, _groundDistance);
        Debug.DrawRay(transform.position, -Vector2.up * _groundDistance, Color.red);
        if (hit.collider != null)
        {
            _isGrounded = true;
            _floatTimer = 3.0f;
        }
        else
        {
            _isGrounded = false;
        }
            moveInput = Input.GetAxis("Horizontal");
        _rb2d.velocity = new Vector2(moveInput * speed, _rb2d.velocity.y);

        FlipModel();

        //animation stuff here

        if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            _ani.SetBool("isWalking", true);

        }
        else
        {
            _ani.SetBool("isWalking", false);
        }

    }




    void FlipModel()
    {
        if ((Input.GetAxisRaw("Horizontal") > 0 && _isFlipped)
            || (Input.GetAxis("Horizontal") < 0 && !_isFlipped)
            )
        {
            _isFlipped = !_isFlipped;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }

}
