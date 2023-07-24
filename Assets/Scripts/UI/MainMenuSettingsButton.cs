using UnityEngine;

namespace UI
{
    public class MainMenuSettingsButton : MonoBehaviour
    {
        public void OnClick()
        {
            GameObject settingsPanel = GameObject.Find("Settings_Panel");
            settingsPanel.transform.localScale = settingsPanel.transform.localScale == Vector3.zero ? settingsPanel.transform.localScale = new Vector3(1f, 1f, 1f) : settingsPanel.transform.localScale = Vector3.zero;
        }
    }
}