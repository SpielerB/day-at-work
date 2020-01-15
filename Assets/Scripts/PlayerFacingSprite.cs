using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * This class is used to turn the managed sprite towards the main camera
     */
    public class PlayerFacingSprite : MonoBehaviour
    {

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
