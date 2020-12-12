using System;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class CharacterMovement : CharacterComponents
{

    public float WalkMoveSpeed { get; set; }
    [SerializeField] private float walkSpeed = 6f;

   

protected override void HandleAbility()
        {
            base.HandleAbility();
            MoveCharacter();
        }

protected override void Start()
{
    base.Start();
    WalkMoveSpeed = walkSpeed;
}
    

        protected void MoveCharacter()
        {
            
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            Vector2 moveInput = movement;
            Vector2 movementNomalized = movement.normalized;
            Vector2 movementSpeed = movementNomalized * WalkMoveSpeed;
            controller.SetMovement(movementSpeed);


        }

        public void SetHorizontal(float value)
        {
            horizontalInput = value;
        }

        public void SetVertical(float value)
        {
            verticalInput = value;
        }

      
      
    }
