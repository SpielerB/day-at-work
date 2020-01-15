using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * Handles the player itself
     */
    public class PlayerController : MonoBehaviour
    {
        /**
         * Where the player is positioned at the beginning of the simulation
         */
        public MovementNode initialMovementPoint;

        /**
         * Holds the current movement point
         */
        public MovementNode CurrentMovementPoint { get; private set; }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            if (initialMovementPoint != null)
            {
                MoveTo(initialMovementPoint);
            }
        }

        /**
         * Resets the players position to either the initial movement point or 0
         */
        public void ResetPosition()
        {
            if (initialMovementPoint != null)
            {
                MoveTo(initialMovementPoint);
            }
            else
            {
                transform.Translate(-transform.position.x, 0, -transform.position.z);
                CurrentMovementPoint = null;
            }
        }

        /**
         * Moves to player to a specific movement node
         */
        public void MoveTo(MovementNode point)
        {
            var target = point.transform.position;
            var origin = transform.position;
            transform.Translate(target.x - origin.x, 0, target.z - origin.z, Space.World);

            if (CurrentMovementPoint != null)
            {
                CurrentMovementPoint.gameObject.SetActive(true);
            }

            point.gameObject.SetActive(false);
            CurrentMovementPoint = point;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
#if UNITY_EDITOR
            // This is a workaround to use unity with remote desktop clients and still be able to look around
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(transform.position, Vector3.down, 40 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(transform.position, Vector3.up, 40 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.right, 40 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.left, 40 * Time.deltaTime);
            }
#endif
        }
    }
}