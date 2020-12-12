using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ai/Actions/Follow", fileName = "ActionFollow")]
public class ActionFollow : AIAction
{

    public float minDistanceToFollow = 1f;
    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller)
    {
        if (controller.Target == null)
        {
            return;
        }
        if(controller.transform.position.x < controller.Target.position.x) 
        {
            controller.CharacterMovement.SetHorizontal(1); 
        }
        else
        {
            controller.CharacterMovement.SetHorizontal(-1);
        }

        if (controller.transform.position.y < controller.Target.position.y)
        {
            controller.CharacterMovement.SetVertical(1);
        }
        else
        {
            controller.CharacterMovement.SetVertical(-1);
        }

        if (Math.Abs(controller.transform.position.x - controller.Target.position.x) < minDistanceToFollow)
        {
            controller.CharacterMovement.SetHorizontal(0);
        }
        
        if (Math.Abs(controller.transform.position.y - controller.Target.position.y) < minDistanceToFollow)
        {
            controller.CharacterMovement.SetVertical(0);
        }
        
        
    }

}
