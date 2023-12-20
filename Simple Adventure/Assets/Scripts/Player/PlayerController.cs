using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private Vector2 direction;

    private bool isGround;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }

        onAnimations();
        onJump();
    }

    private void FixedUpdate() {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }

    void onAnimations() {
        if(isGround) {
            if(direction.x > 0 || direction.x < 0) {
                anim.SetInteger("transition", 1);
            } else {
                anim.SetInteger("transition", 0);
            }
        } else {
            anim.SetInteger("transition", 2);
        }
    }

    void onJump() {
        if(isGround) {
            if(Input.GetButtonDown("Jump")) {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 3) {
            isGround = true;
        }
    }
}
