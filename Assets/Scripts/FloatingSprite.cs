using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    public class FloatingSprite : PlayerFacingSprite
    {
        public float amplitude = 0.25f;
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
