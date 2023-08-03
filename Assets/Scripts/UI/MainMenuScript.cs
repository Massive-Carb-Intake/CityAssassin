using UnityEngine;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        private GameObject _settingsPanel;
        private GameObject _menuCanvas;
        private GameObject _gameCanvas;
        

        void Start()
        {
            _settingsPanel = GameObject.Find("Settings_Panel");
            _menuCanvas = GameObject.Find("Main_Menu_Canvas");
            _gameCanvas = GameObject.Find("Main_Game_Canvas");
        }
        
        
        public void OnSettingsButtonClick()
        {
            _settingsPanel.transform.localScale = _settingsPanel.transform.localScale == Vector3.zero ? _settingsPanel.transform.localScale = new Vector3(1f, 1f, 1f) : _settingsPanel.transform.localScale = Vector3.zero;
        }
        
        public void OnStartGameButtonClick()
        {
            // CALL START GAME FUNCTION **** 
            _menuCanvas.GetComponent<Canvas>().enabled = false;
            _gameCanvas.GetComponent<Canvas>().enabled = true;

        }
    }
}