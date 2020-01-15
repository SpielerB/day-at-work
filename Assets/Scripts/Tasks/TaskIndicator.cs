using UnityEngine;

namespace Assets.Scripts.Tasks
{
    /**
     * This class manages the task indicator
     */
    public class TaskIndicator : FloatingSprite
    {

        /**
         * Moves the indicator to the target transform
         */
        public void MoveTo(Transform target)
        {
            var pos = transform.position;
            var oPos = target.position;
            transform.Translate(oPos.x - pos.x, 0, oPos.z - pos.z, Space.World);
            offset = transform.position;
        }
    }
}
