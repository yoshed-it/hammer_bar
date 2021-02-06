using UnityEngine;
using PolyNav;

namespace BehaviorDesigner.Runtime.Tasks.Movement.PolyNav
{
    public abstract class PolyNavGroupMovement : GroupMovement
    {
        [Tooltip("All of the agents")]
        public SharedGameObject[] agents = null;

        protected Transform[] transforms;
        private PolyNavAgent[] polyNavAgents;

        public override void OnAwake()
        {
            transforms = new Transform[agents.Length];
            polyNavAgents = new PolyNavAgent[agents.Length];
            for (int i = 0; i < agents.Length; ++i) {
                polyNavAgents[i] = agents[i].Value.GetComponent<PolyNavAgent>();
                transforms[i] = agents[i].Value.transform;

                polyNavAgents[i].enabled = true;
            }
        }

        protected override bool SetDestination(int index, Vector3 target)
        {
            return polyNavAgents[index].SetDestination(target);
        }

        protected override Vector3 Velocity(int index)
        {
            return polyNavAgents[index].movingDirection * polyNavAgents[index].currentSpeed;
        }

        public override void OnEnd()
        {
            for (int i = 0; i < agents.Length; ++i) {
                if (agents[i] != null) {
                    polyNavAgents[i].enabled = false;
                }
            }
        }
    }
}