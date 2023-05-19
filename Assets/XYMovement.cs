using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Mode mode;
    [SerializeField] float speed;

    Vector2 direction;

    public Vector2 Direction { get => direction; }

    enum Mode
    {
        Platformer,
        TopDown   
    }

    private void Start() {
        rb.gravityScale = mode == Mode.TopDown ? 0 : 1;
    }

    private void Update() {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal,vertical);
        direction.Normalize();        
    }

    private void FixedUpdate() {
        switch (mode)
        {
            case Mode.Platformer:
                break;
            case Mode.TopDown:
                rb.velocity = speed * direction;
                break;            
        }
    }
}
