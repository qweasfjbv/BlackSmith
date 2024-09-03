using UnityEngine;

namespace Resource
{
    public class Resource_Tree : ResourceBase
    {
        private void Awake()
        {
            SetResourceInfo(Constants.ANIM_PARAM_CHOP, Constants.ANIM_CLIPNAME_CHOP, 0.3f, 45f);
        }

        public override int GetResource()
        {

            // TODO : PLAY SOUND
            Debug.Log("TUCK!");
            return -1;
        }

        public override void OnUpdate()
        {

        }
    }
}