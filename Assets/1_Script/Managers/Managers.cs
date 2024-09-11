using UnityEngine;

namespace Manager
{
    public class Managers : MonoBehaviour
    {

        static Managers s_instance;

        private InvenManager _inven = new InvenManager();
        private ResourceManager _resource = new ResourceManager();


        public static Managers Instance { get { return s_instance; } }

        public static ResourceManager Resource { get { return Instance._resource; } }
        public static InvenManager Inven { get { return Instance._inven; } }


        void Awake()
        {
            Init();
        }


        private void Init()
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();

            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            s_instance._resource.Init();

        }

    }
}