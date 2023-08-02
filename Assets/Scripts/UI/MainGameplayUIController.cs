using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace UI
{
    public class MainGameplayUIController : MonoBehaviour
    {
        private Transform _deathPanel;

        private Transform _gameplayUI;

        private Button _watchVideoButton;

        private UnityAction _rewardedVideoAction;

        private GameObject _player;

        private GameMode _gameMode;

        
        
        // Start is called before the first frame update
        void Start()
        {
            _deathPanel = gameObject.transform.Find("Safe_Area").Find("Death_Panel");
            _gameplayUI = gameObject.transform.Find("Safe_Area").Find("Gameplay_UI");
            _deathPanel.localScale = Vector3.zero;
            _watchVideoButton = _deathPanel.Find("Back_To_Menu_Button").gameObject.GetComponent<Button>();
            _rewardedVideoAction += GetComponent<IronSourceAds>().ShowRewardedAd;
            _player = GameObject.Find("Player");
            _gameMode = _player.GetComponent<GameMode>();
        }

        // Update is called once per frame
        // void Update()
        // {
        //     
        // }

        public void ShowDeathScreen()
        {
            _deathPanel.localScale = new Vector3(1f, 1f, 1f);
            _gameplayUI.localScale = Vector3.zero;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += onRewarded;
        }
        
        private void ShowGameScreen()
        {
            _gameplayUI.localScale = new Vector3(1f, 1f, 1f);
            _deathPanel.localScale = Vector3.zero;
            IronSourceRewardedVideoEvents.onAdRewardedEvent -= onRewarded;
        }

        public void BackToMenu()
        {
            IronSourceRewardedVideoEvents.onAdRewardedEvent -= onRewarded;
            _gameMode.EndGame();
        }


        private void onRewarded(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            ShowGameScreen();
            _gameMode.Resurrect();
        }
        
        
        
        
    }
    
}
