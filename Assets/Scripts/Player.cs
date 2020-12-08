using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    
   
    public Animator animator;
    private Rigidbody2D rb2b;
    

    void Awake()
    {
        rb2b = GetComponent<Rigidbody2D>();
        
        // SetUpCamera();
    }

    void FixedUpdate()
    {   
        
        PlayerMovement();
        PlayerDirectionAnimation();
    }

     private void PlayerMovement()
    {

        rb2b.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("HorizontalKey") * movementSpeed, 0.8f),
                                    Mathf.Lerp(0, Input.GetAxisRaw("VerticalKey") * movementSpeed, 0.8f));
                                    rb2b.freezeRotation = true;   
                                      
    }

        private void PlayerDirectionAnimation()
        {
            animator.SetFloat("Horizontal", Input.GetAxisRaw("HorizontalKey"));
            animator.SetFloat("Vertical", Input.GetAxisRaw("VerticalKey"));
            Debug.Log(Input.GetAxisRaw("VerticalKey"));
        }
}
