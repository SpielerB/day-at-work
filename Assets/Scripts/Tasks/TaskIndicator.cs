using UnityEngine;

namespace Assets.Scripts.Tasks
{
    public class TaskIndicator : FloatingSprite
    {

        public void MoveTo(Transform target)
        {
            var pos = transform.position;
            var oPos = target.position;
            transform.Translate(oPos.x - pos.x, 0, oPos.z - pos.z, Space.World);
            offset = transform.position;
        }
    }
}
