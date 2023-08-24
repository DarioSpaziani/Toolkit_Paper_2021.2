using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit
{
    public class MenuControllerToolkit : MonoBehaviour
    {
        #region Variables

        [Header("Mute Button")] [SerializeField]
        private Sprite mutedSprite;

        [SerializeField] private Sprite unmutedSprite;
        private bool _muted;

        [Header("Settings")] [SerializeField] private VisualTreeAsset settingsButtonsTemplate;
        private VisualElement _buttonsWrapper;
        private VisualElement _settingsButtons;
        private Button _settingsButton;

        private UIDocument _doc;
        private Button _playButton;
        private Button _exitButton;
        private Button _muteButton;

        #endregion

        private void Awake()
        {
            _doc = GetComponent<UIDocument>();

            _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
            _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
            _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
            _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
            _buttonsWrapper = _doc.rootVisualElement.Q<VisualElement>("Buttons");

            _playButton.clicked += OnPlayButtonClicked;
            _settingsButton.clicked += OnSettingsButtonClicked;
            _exitButton.clicked += OnExitButtonClicked;
            _muteButton.clicked += OnMuteButtonClicked;

            _settingsButtons = settingsButtonsTemplate.CloneTree();

            var backButton = _settingsButtons.Q<Button>("BackButton");
            backButton.clicked += OnBackButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("Game_UI");
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }

        private void OnMuteButtonClicked()
        {
            _muted = !_muted;
            var background =
                _muteButton.style
                    .backgroundImage; //first get the reference to the background image style from the button style
            background.value =
                Background.FromSprite(_muted
                    ? mutedSprite
                    : unmutedSprite); //then we assign a new sprite using this method (the value depends on the muted value)
            _muteButton.style.backgroundImage = background; //then reassign the value to the style

            AudioListener.volume = _muted ? 0 : 1;
        }

        private void OnSettingsButtonClicked()
        {
            _buttonsWrapper.Clear();
            _buttonsWrapper.Add(_settingsButtons);
        }

        private void OnBackButtonClicked()
        {
            _buttonsWrapper.Clear();
            _buttonsWrapper.Add(_playButton);
            _buttonsWrapper.Add(_settingsButton);
            _buttonsWrapper.Add(_exitButton);
        }
    }
}