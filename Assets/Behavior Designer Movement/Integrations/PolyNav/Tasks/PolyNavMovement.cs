using UnityEngine;
using PolyNav;

namespace BehaviorDesigner.Runtime.Tasks.Movement.PolyNav
{
    public abstract class PolyNavMovement : Movement
    {
        [Tooltip("The speed of the agent")]
        public SharedFloat speed = 5;
        [Tooltip("Angular speed of the agent")]
        public SharedFloat angularSpeed = 350;

        private bool destinationReached = false;
        private Vector3 prevDestination;
        // A cache of the PolyNavAgent
        private PolyNavAgent polyNavAgent;
        
        public override void OnAwake()
        {
            polyNavAgent = gameObject.GetComponent<PolyNavAgent>();
        }

        public override void OnStart()
        {
            destinationReached = false;
            prevDestination = transform.position;

            polyNavAgent.maxSpeed = speed.Value;
            polyNavAgent.rotateSpeed = angularSpeed.Value;
        }

        protected override bool SetDestination(Vector3 destination)
        {
            if (destination != prevDestination) {
                prevDestination = destination;
                destinationReached = false;
                return polyNavAgent.SetDestination(destination, OnDestinationReached);
            }
            return false;
        }

        protected override bool HasArrived()
        {
            return destinationReached;
        }

        protected override bool HasPath()
        {
            return polyNavAgent.hasPath;
        }

        protected override Vector3 Velocity()
        {
            return polyNavAgent.movingDirection * polyNavAgent.currentSpeed;
        }

        protected override void UpdateRotation(bool update)
        {
            // Intentionally left blank.
        }

        protected override void Stop()
        {
            polyNavAgent.Stop();
        }

        private void OnDestinationReached(bool arrived)
        {
            destinationReached = true;
        }

        public override void OnEnd()
        {
            Stop();
        }

        // Reset the public variables
        public override void OnReset()
        {
            speed = 5;
            angularSpeed = 10;
        }
    }
}