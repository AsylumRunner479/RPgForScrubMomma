using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Setting : MonoBehaviour
{
    public static bool SettingsOpen;
    
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    //public KeyBinds[] keys;
    struct KeyBinds
    {
        public string name;
        public KeyCode key;
    };
    public Text keyButtons;
    public Text fowardButton, backwardButton;
    public KeyCode forward, backward, tempKey;
    void Start()
    {
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        fowardButton.text = forward.ToString();
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        backwardButton.text = backward.ToString();
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = 1;
            }

        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue(); 

     }
    public void Forward()
    {
        if (backward != KeyCode.None)
        {
            tempKey = forward;
            forward = KeyCode.None;
        }
        forwardButton.text = forward.ToString();
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if (forward == KeyCode.None)
        {
            if (e.keyCode != backward)
            {
                forward = e.keyCode;
                forwardButton.text = forward.ToString();
            }
            else
            {
                forward = tempKey;
                forwardButton.text = forward.ToString();
            }
        }
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if(SettingsOpen)
        {
            Time.timeScale = 0;
        }
        else if (!SettingsOpen)
        {
            Time.timeScale = 1;
        }
    }
}
