using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit
{
    public class MapController : MonoBehaviour
{
    public GameObject Player;
    private VisualElement _root;
    private VisualElement _playerRepresentation;
    private VisualElement _mapContainer;
    private VisualElement _mapImage;
    
    [Range(1, 15)] public float miniMultiplyer = 1f;
    [Range(1, 15)] public float fullMultiplyer = 1f;
    
    private bool _mapFaded;
    
    private bool IsMapOpen => _root.ClassListContains("root-container-full");
    
    public bool MapFaded
    {
        get => _mapFaded; 
        
        set
        {
            if (_mapFaded == value)
            {
                return;
            }

            Color end = !_mapFaded ? Color.white.WithAlpha(.5f) : Color.white;                
        
            _mapImage.experimental.animation.Start(
                _mapImage.style.unityBackgroundImageTintColor.value, end, 500, 
                (elm, val) => { elm.style.unityBackgroundImageTintColor = val; });

            _mapFaded = value;
        }
    }

    void Start()
    {
        _root = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>
            ("Container");
        _playerRepresentation = _root.Q<VisualElement>("Player");
        _mapImage = _root.Q<VisualElement>("Image");
        _mapContainer = _root.Q<VisualElement>("Map");
    }
    
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap(!IsMapOpen);
        }
        
        var multiplyer = IsMapOpen ? fullMultiplyer : miniMultiplyer;
        _playerRepresentation.style.translate = 
            new Translate(Player.transform.position.x * multiplyer, 
            Player.transform.position.z * -multiplyer, 0);
        _playerRepresentation.style.rotate = new Rotate(
            new Angle(Player.transform.rotation.eulerAngles.y));

        if (!IsMapOpen)
        {
            var clampWidth = _mapImage.worldBound.width / 2 - 
                                _mapContainer.worldBound.width / 2;
            var clampHeight = _mapImage.worldBound.height / 2 - 
                                _mapContainer.worldBound.height / 2;

            var xPos = Mathf.Clamp(Player.transform.position.x * -miniMultiplyer, 
                -clampWidth, clampWidth);
            var yPos = Mathf.Clamp(Player.transform.position.z * miniMultiplyer, 
                -clampHeight, clampHeight);

            _mapImage.style.translate = new Translate(xPos, yPos, 0);
        }
        else
        {
            _mapImage.style.translate = new Translate(0, 0, 0);
        }
    }

    private void ToggleMap(bool on)
    {
        _root.EnableInClassList("root-container-mini", !on);
        _root.EnableInClassList("root-container-full", on);
    }
}
}