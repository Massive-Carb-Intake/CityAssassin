using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



namespace UI
{
    public class MainGameplayUIController : MonoBehaviour
    {
        private Transform _safeArea;
        
        private Transform _deathPanel;

        private Transform _gameplayUI;

        private Button _watchVideoButton;

        private UnityAction _rewardedVideoAction;

        private GameObject _ironSourceGO;

        private IronSourceAds _ironSourceScript;

        private GameObject _player;

        private GameMode _gameMode;
        
        private PlayerController _playerController;

        private float _watchVideoTimerInitialValue;

        private bool _watchVideoButtonClicked;

        private TMP_Text _reviveCountdownTextTMP;

        private Timer _watchVideoTimer;

        private bool _deathScreenShown;

        private GameObject _resumeCountdownTextGO;
        private TMP_Text _resumeCountdownTextTMP;

        private Timer _resumeTimer;
        
        private float _resumeTimerInitialValue;
        
        
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            _safeArea = gameObject.transform.Find("Safe_Area");
            _deathPanel = _safeArea.Find("Death_Panel");
            _gameplayUI = _safeArea.Find("Gameplay_UI");
            _reviveCountdownTextTMP = GameObject.Find("Revive_Countdown_Text").GetComponent<TMP_Text>();
            _watchVideoButton = _deathPanel.Find("Watch_Video_Button").gameObject.GetComponent<Button>();
            _ironSourceGO = GameObject.Find("IronSource_Object");
            _ironSourceScript = _ironSourceGO.GetComponent<IronSourceAds>();
            _resumeCountdownTextGO = GameObject.Find("Resume_Timer_Text");
            _resumeCountdownTextTMP = _resumeCountdownTextGO.GetComponent<TMP_Text>();

            
            _player = GameObject.Find("Player");
            _gameMode = _player.GetComponent<GameMode>();
            _playerController = _player.GetComponent<PlayerController>();
            
            
            _deathPanel.localScale = Vector3.zero;
            
            _rewardedVideoAction += GetComponent<IronSourceAds>().ShowRewardedAd;
            
            _watchVideoTimerInitialValue = 5f;
            _watchVideoButtonClicked = false;

            _watchVideoTimer = new Timer();
            _watchVideoTimer.SetTimer(_watchVideoTimerInitialValue);

            _resumeTimerInitialValue = 3f;

            _resumeTimer = new Timer();
            _resumeTimer.SetTimer(_resumeTimerInitialValue);
            

        }
        

        // Update is called once per frame
        void Update()
        {
            _watchVideoTimer.Update(Time.unscaledDeltaTime);
            _resumeTimer.Update(Time.unscaledDeltaTime);
            if (_watchVideoTimer.IsRunning())
            {
                _reviveCountdownTextTMP.text = Convert.ToString(Mathf.Ceil(_watchVideoTimer.GetSecondsRemaining()));
            }
            if (_watchVideoTimer.IsComplete() && !_watchVideoButtonClicked)
            {
                _watchVideoButton.gameObject.transform.localScale = Vector3.zero;
                _reviveCountdownTextTMP.color = Color.red;
                _watchVideoTimer.ResetTimer();
            }
            
            if (_resumeTimer.IsRunning())
            {
                _resumeCountdownTextTMP.text = Convert.ToString(Mathf.Ceil(_resumeTimer.GetSecondsRemaining()));
            }
            if (_resumeTimer.IsComplete())
            {
                _resumeCountdownTextGO.transform.localScale = Vector3.zero;
                _resumeTimer.ResetTimer();
                _resumeCountdownTextTMP.text = Convert.ToString(_resumeTimerInitialValue);
                _gameMode.UnpauseGame();
            }
            
        }
 
        public void ShowDeathScreen()
        {
            _deathScreenShown = true;
            _deathPanel.localScale = Vector3.one;
            _gameplayUI.localScale = Vector3.zero;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += OnRewarded;
            _watchVideoTimer.StartTimer();
        }
        
        private void Resurrect()
        {
            ResetUIState();
            _gameMode.Resurrect();
            _gameMode.PauseGame();
            _resumeCountdownTextGO.transform.localScale = Vector3.one;
            IronSourceRewardedVideoEvents.onAdClosedEvent -= OnRewardedAndClosed;
            _resumeTimer.StartTimer();
            
        }

        public void BackToMenu()
        {
            _deathScreenShown = false;
            IronSourceRewardedVideoEvents.onAdRewardedEvent -= OnRewarded;
            IronSourceRewardedVideoEvents.onAdClosedEvent -= OnRewardedAndClosed;
            _gameMode.EndGame();
        }


        private void OnRewarded(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            IronSourceRewardedVideoEvents.onAdRewardedEvent -= OnRewarded;
            IronSourceRewardedVideoEvents.onAdClosedEvent += OnRewardedAndClosed;
            
        }

        private void OnRewardedAndClosed(IronSourceAdInfo adInfo)
        {
            _deathScreenShown = false;
            Resurrect();
        }
        

        public void OnVideoButtonClick()
        {
            _watchVideoButtonClicked = true;
            _watchVideoTimer.ResetTimer();
            _ironSourceScript.ShowRewardedAd();
        }

        public void CallJump()
        {
            _playerController.Jump();
        }

        public bool DeathScreenShown()
        {
            return _deathScreenShown;
        }

        private void ResetUIState()
        {
            _gameplayUI.localScale = Vector3.one;
            _deathPanel.localScale = Vector3.zero;
            _reviveCountdownTextTMP.color = Color.black;
            _watchVideoButton.gameObject.transform.localScale = Vector3.one;
            _reviveCountdownTextTMP.text = Convert.ToString(_watchVideoTimerInitialValue);



        }
        
        
    }
    
}
