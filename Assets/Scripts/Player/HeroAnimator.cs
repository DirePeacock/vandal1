using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    //References
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRederer;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRederer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerMovement.movementDirection.x != 0 || playerMovement.movementDirection.y != 0)
        {
            animator.SetBool("Moving", true);

            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (playerMovement.lastHorizontalVector < 0)
        {
            spriteRederer.flipX = true;
        }
        else
        {
            spriteRederer.flipX = false;
        }
    }
}
