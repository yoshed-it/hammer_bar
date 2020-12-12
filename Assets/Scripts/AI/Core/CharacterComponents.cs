using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
   protected float horizontalInput;
   protected float verticalInput;
   
   protected Character character;
   protected CharacterController controller;
   protected CharacterMovement characterMovement;

   protected virtual void Start()
   {   
      controller = GetComponent<CharacterController>();
      character = GetComponent<Character>();
      characterMovement = GetComponent<CharacterMovement>();
   }

   protected virtual void Update()
   {
      HandleAbility();
   }

   protected virtual void HandleAbility()
   {
      InternalInput();
      HandleInput();
   }

   protected virtual void HandleInput()
   {
      
   }

   protected virtual void InternalInput()
   {
      if (character.characterType == Character.CharacterTypes.Player)
      {
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");
      }
      
   }
}
