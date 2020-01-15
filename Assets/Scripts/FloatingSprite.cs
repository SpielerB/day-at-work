using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * This class manages the animation of floating sprites so they move up and down
     */
    public class FloatingSprite : PlayerFacingSprite
    {
        /**
         * How high the sprite floats up and down
         */
        public float amplitude = 0.25f;

        /**
         * How fast the sprite floats up and down
         */
        public float frequency = 1.25f;

        protected Vector3 offset;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            offset = transform.position;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        protected void Update()
        {
            var position = offset;
            position.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = position;
        }
    }
}
