using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundEffectsSlider;
    [SerializeField] private AudioSource _musicAudio;
    [SerializeField] private AudioSource[] _soundEffectsAudio;

    private static readonly string _firstPlay = "FirstPlay";
    private static readonly string _musicPref = "MusicPref";
    private static readonly string _soundEffectsPref = "Sound EffectsPref";
    private float _musicFloat;
    private float _soundEffectsFloat;
    private int _firstPlayInt;



    private void Start()
    {
        _firstPlayInt = PlayerPrefs.GetInt(_firstPlay);

        if (_firstPlayInt == 0)
        {
            _musicSlider.value = _musicFloat;
            _soundEffectsSlider.value = _soundEffectsFloat;

            PlayerPrefs.SetFloat(_musicPref, _musicFloat);
            PlayerPrefs.SetFloat(_soundEffectsPref, _soundEffectsFloat);
            PlayerPrefs.SetInt(_firstPlay, -1);
        }

        else
        {
            _musicFloat = PlayerPrefs.GetFloat(_musicPref);
            _musicSlider.value = _musicFloat;

            _soundEffectsFloat = PlayerPrefs.GetFloat(_soundEffectsPref);
            _soundEffectsSlider.value = _soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(_musicPref, _musicSlider.value);
        PlayerPrefs.SetFloat(_soundEffectsPref, _soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        _musicAudio.volume = _musicSlider.value;

        for (int i = 0; i < _soundEffectsAudio.Length; i++)
        {
            _soundEffectsAudio[i].volume = _soundEffectsSlider.value;
        }
    }
}
