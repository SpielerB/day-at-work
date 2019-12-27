using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    public class FloatingSprite : MonoBehaviour
    {
        public float amplitude = 0.25f;
        public float frequency = 1.25f;

        private Vector3 offset;
        private Vector3 position;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            offset = transform.position;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Update()
        {
            position = offset;
            position.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = position;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
