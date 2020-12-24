using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;


    public Animator animator;
    private Rigidbody2D rb2b;
    public Text beer;


    void Awake()
    {
        rb2b = GetComponent<Rigidbody2D>();

        // SetUpCamera();
    }

    void FixedUpdate()
    {

        PlayerMovementInput();
        PlayerDirectionAnimation();
        // LockBeerToCharacter();
    }

    private void PlayerMovementInput()
    {
        rb2b.freezeRotation = true;
        rb2b.velocity.Normalize();
        rb2b.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("HorizontalKey") * movementSpeed, 0.8f),
                                    Mathf.Lerp(0, Input.GetAxisRaw("VerticalKey") * movementSpeed, 0.8f));
    }

    private void PlayerDirectionAnimation()
    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("HorizontalKey"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("VerticalKey"));
    }

    // void LockBeerToCharacter()
    // {
    //     Vector2 beerPosition = new Vector2(beer.transform.position.x, beer.transform.position.y);
    //     transform.position = rb2b.velocity;
    // }

}
