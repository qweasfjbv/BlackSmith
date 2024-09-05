using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Field
{
    public class WorkUI : MonoBehaviour
    { 
        private Transform player;  

        [SerializeField] private GameObject timingPin;
        [SerializeField] private GameObject corrTImingPin;
        [SerializeField] private Image progressBar;

        private float maxRangeWidth;

        public void SetWorkUI(int facId, Transform player)
        {
            this.player = player;

        }

        public void SetTiming(float maxTiming, float correctTiming, float correctTimingRange)
        {
            maxRangeWidth = corrTImingPin.transform.parent.GetComponent<RectTransform>().sizeDelta.x * 0.8f;

            corrTImingPin.GetComponent<RectTransform>().anchoredPosition =
                new Vector3(maxRangeWidth * (correctTiming - 0.5f), 0, 0);

            corrTImingPin.GetComponent<RectTransform>().sizeDelta = new Vector2(maxRangeWidth * correctTimingRange / maxTiming, 15f);
            
        }

        public void SetPinPos(float ratio)
        {
            timingPin.GetComponent<RectTransform>().anchoredPosition = new Vector3(maxRangeWidth * (ratio-0.5f), 0, 0);
        }

        public void SetProgressBar(float ratio)
        {
            progressBar.fillAmount = ratio;
        }

        void Update()
        {
            transform.position = player.position + new Vector3(0, 2.5f, -0.5f);
            transform.rotation = Camera.main.transform.rotation;
        }
    }

}