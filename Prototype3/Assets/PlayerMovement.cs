using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private float dirX, dirY;
    private SpriteRenderer sprite;
    private float moveSpeed = 7f;
    private float jumpForce = 14f;
    private bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed,rb.velocity.y);
        sprite = GetComponent<SpriteRenderer>();


        if (IsGrounded)
        {

            //JUMP
            

        


        if (Input.GetButtonDown("Jump") && dirY > 0)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && dirY < 0)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") )
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            var list = GameObject.FindGameObjectsWithTag("monster");
            foreach (var e in list)
            {
                e.GetComponent<BoxCollider2D>().enabled = true;

            }
                var list2 = GameObject.FindGameObjectsWithTag("platform");
                foreach (var e in list2)
                {
                    e.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        UpdateAnimationState();
    }


    private void UpdateAnimationState()
    {
        
        if (dirX > 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;

        }
        else if (dirX < 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("platform"))
        {
            IsGrounded = true;

        }
    }
private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("platform"))
        {
            IsGrounded = false;
        }
        
    }




}
