using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] XYMovement movement;

    Vector2 lastDir;
    void Update()
    {
        spriteRenderer.flipX = lastDir == Vector2.left;

        if (movement.Direction != Vector2.zero)
        {
            lastDir = movement.Direction;

            if (movement.Direction == Vector2.up)
            {
                animator.Play("Knight Walk Up");
            }
            else if (movement.Direction == Vector2.down)
            {
                animator.Play("Knight Walk Down");
            }
            else if (movement.Direction == Vector2.right || movement.Direction == Vector2.left)
            {
                animator.Play("Knight Walk Right");
            }
        }
        else
        {
            if (lastDir == Vector2.up)
            {
                animator.Play("Knight Idle Up");
            }
            else if (lastDir == Vector2.down)
            {
                animator.Play("Knight Idle Down");
            }
            else if (lastDir == Vector2.right || lastDir == Vector2.left)
            {
                animator.Play("Knight Idle Right");
            }
        }
    }
}
