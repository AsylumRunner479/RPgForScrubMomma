using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Setting : MonoBehaviour
{
    public static bool SettingsOpen;
    //allows you to set the sound right
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;
    //gives you an array for different resolution options
    Resolution[] resolutions;
    // Start is called before the first frame update
    //public KeyBinds[] keys;
   
    struct KeyBinds
    {
        public string name;
        public KeyCode key;
    };
    //allows you to set what kind of keys you use to do various things
    public Text keyButtons;
    public Text forwardButton, backwardButton;
    public KeyCode forward, backward, tempKey;
    void Start()
    {
        //sets the defaults
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        forwardButton.text = forward.ToString();
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
    public void Forward()
    {
        //allows you to change what you do to go forward
        if (backward != KeyCode.None)
        {
            tempKey = forward;
            forward = KeyCode.None;
        }
        forwardButton.text = forward.ToString();
    }
    
    public void SetVolume(float volume)
    {
        //allows you to set the volume in the main menu
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        //allows you to decide whether you are in the fullscreen
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        //allows you to choose from an index of qualities
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        //allows you to set the resolution from an index
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
     //changes timescale based on whther the setting is open
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
