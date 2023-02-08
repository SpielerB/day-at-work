using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * Handles the player itself
     */
    public class PlayerController : MonoBehaviour
    {
        Vector2 rotation = new Vector2(0, 0);
        public float speed = 3;

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

            rotation = transform.eulerAngles;
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

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
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
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            transform.eulerAngles = (Vector2)rotation * speed;
        }
    }
}