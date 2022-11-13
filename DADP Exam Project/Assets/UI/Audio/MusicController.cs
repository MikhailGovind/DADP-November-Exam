/*Script created by Mikhail
 * Created: 13/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";

    private int firstPlayInt;
    private float musicFloat;

    public Slider musicSlider;
    public AudioSource musicAudio; 

    // Start is called before the first frame update
    void Start()
    {
        //assign variable to PlayerPrefs for first time audio is played
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        //if the firs time the audio is played is has a value of 0 make it have some value
        if (firstPlayInt == 0)
        {
            musicFloat = 0.2f; //giving the float a value
            musicSlider.value = musicFloat; //assigning the above float to the value on slider
            PlayerPrefs.SetFloat(MusicPref, musicFloat); //setting the float to MusicPref and PlayerPrefs
            PlayerPrefs.SetInt(FirstPlay, -1); //set first play value to 0
        }
        else //if first play value is not 0
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref); //assign the volume level to the MusicPrefs float above
            musicSlider.value = musicFloat; //make the volume level equal to the value on slider
        }
    }

    //function to save settings
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value); //saves current settings that are currently on the slider to PlayerPrefs
    }

    //calls function above when application is called or minimized
    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    //when slider value is changed, it changes the volume level on audio source
    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
    }
}
