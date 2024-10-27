using UnityEngine;

namespace MiniGameCollection.Games2024.Team00
{
    public class PlayerJump : MiniGameBehaviour
    {
        [field: SerializeField, Range(1, 2)]
        private int PlayerID { get; set; } = 1;

        [field: SerializeField]
        private bool ControlsActive { get; set; }

        [field: SerializeField]
        private Rigidbody Rigidbody { get; set; }

        [field: SerializeField]
        private float Force { get; set; } = 10;

        private int ID => PlayerID - 1;
        private bool DoJump;

        protected override void OnGameStart()
        {
            ControlsActive = true;
        }

        protected override void OnGameEnd()
        {
            ControlsActive = false;
        }

        private void Update()
        {
            if (ArcadeInput.Players[ID].Action1.Down)
            {
                DoJump = true;
            }
        }

        private void FixedUpdate()
        {
            if (!ControlsActive)
                return;

            if (!DoJump)
                return;
            DoJump = false;

            if (!IsGrounded())
                return;

            Vector3 force = Vector3.up * Force * Rigidbody.mass;
            Rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private bool IsGrounded()
        {
            float distance = 0.1f;
            float halfDistance = distance / 2;
            Vector3 origin = transform.position + Vector3.up * halfDistance;
            Vector3 direction = Vector3.down;
            int layerMask = ~0;
            bool hit = Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, layerMask, QueryTriggerInteraction.Ignore);
            
            if (hitInfo.rigidbody == Rigidbody)
            {
                Debug.LogError("TODO: make mask ignore self.");
                Debug.Break();
            }

            return hit;
        }
    }
}