using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 direction;

    [SerializeField] private float speed;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update() {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void FixedUpdate() {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }
}
