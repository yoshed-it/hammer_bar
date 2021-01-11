using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement.PolyNav
{
    [TaskDescription("Wander using PolyNav.")]
    [TaskCategory("Movement/PolyNav")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/Movement/documentation.php?id=9")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}WanderIcon.png")]
    public class Wander : PolyNavMovement
    {
        [Tooltip("How far ahead of the current position to look ahead for a wander")]
        public SharedFloat wanderDistance = 20;
        [Tooltip("The amount that the agent rotates direction")]
        public SharedFloat wanderRate = 2;

        public override void OnStart()
        {
            base.OnStart();

            SetDestination(Target());
        }

        // There is no success or fail state with wander - the agent will just keep wandering
        public override TaskStatus OnUpdate()
        {
            if (HasArrived()) {
                SetDestination(Target());
            }
            return TaskStatus.Running;
        }

        private Vector3 Target()
        {
            // point in a new random direction and then multiply that by the wander distance
            var direction = transform.forward + Random.insideUnitSphere * wanderRate.Value;
            return transform.position + direction.normalized * wanderDistance.Value;
        }

        // Reset the public variables
        public override void OnReset()
        {
            wanderDistance = 20;
            wanderRate = 2;
        }
    }
}