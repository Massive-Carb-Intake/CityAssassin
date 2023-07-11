using UnityEngine;

namespace UI
{
    public class UISafeArea : MonoBehaviour
    {

        private Rect safeArea;
        private RectTransform newSafeArea;
        private DeviceOrientation lastOrientation;

        // Start is called before the first frame update
        void Start()
        {
            safeArea = Screen.safeArea;
            newSafeArea = GetComponent<RectTransform>();
            lastOrientation = Input.deviceOrientation;

            FixSafeArea();
        }

        // Update is called once per frame

        void Update()
        {
            if (Input.deviceOrientation != lastOrientation)
            {
                lastOrientation = Input.deviceOrientation;
                FixSafeArea();

            }
        }


        void FixSafeArea()
        {
            safeArea = Screen.safeArea;

            // WORKS FOR CANVAS SCALER CONSTANT PIXEL SIZE
            /*
            newSafeArea.offsetMin = new Vector2(safeArea.xMin, safeArea.yMin);
            newSafeArea.offsetMax = new Vector2(safeArea.xMax - Screen.width, safeArea.yMax - Screen.height);
            */

            // WORKS FOR CANVAS SCALER SCALE WITH SCREEN SIZE
            newSafeArea.anchorMin = new Vector2(safeArea.xMin / Screen.width, safeArea.yMin / Screen.height);
            newSafeArea.anchorMax = new Vector2(safeArea.xMax / Screen.width, safeArea.yMax / Screen.height);
        }
    }
}