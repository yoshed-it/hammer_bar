using UnityEngine;


    public class CharacterFlip : CharacterComponents
    {
        public enum FlipMode
        {
            MovementDirection
        }

        [SerializeField] private FlipMode flipMode = FlipMode.MovementDirection;
        [SerializeField] private float threshold = 0.1f;

        protected override void HandleAbility()
        {
            base.HandleAbility();
            if (flipMode == FlipMode.MovementDirection)
            {
                FlipToMoveDirection();
            }
            
        }
        private  void FlipToMoveDirection()
        {
            if (controller.CurrentMovement.normalized.magnitude > threshold)
            {
                if (controller.CurrentMovement.normalized.x > 0)
                {
                  FaceDirection(1);  
                }
                else
                {
                    FaceDirection(-1);
                }
            }
        }

        private void FaceDirection(int newDirection)
        {
            if (newDirection == 1)
            {
                transform.localScale = new Vector3(1,1, 1);
                
            }
            else
            {
                transform.localScale = new Vector3(-1, -1, -1);
            }
        }
    }
