using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class VolumeConfigurator : MonoBehaviour
{
    [SerializeField] private string busName;
    
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;
    
    private const string busPath = "bus:/";
    private Bus bus;

    public void Start()
    {
        toggle.onValueChanged.AddListener(ToggleVolume);
        slider.onValueChanged.AddListener(ChangeVolume);
        
        bus = RuntimeManager.GetBus(busPath + busName);
    }

    private void ToggleVolume(bool muted)
    {
        bus.setMute(!muted);
    }

    private void ChangeVolume(float value)
    {
        bus.setVolume(value);
    }
}
