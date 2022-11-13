/*Script created by Mikhail
 * Created: 13/11/2022
 * Modified: */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingScript : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private float musicFloat;
    public AudioSource musicAudio;

    private void Awake()
    {
        ContinueSettings(); //calling function below when game launches
    }

    private void ContinueSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref); //remembering the value on slider

        musicAudio.volume = musicFloat; //assigning value to the volume
    }
}
