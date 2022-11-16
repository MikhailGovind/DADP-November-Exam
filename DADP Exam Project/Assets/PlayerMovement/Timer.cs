using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
	public float TimeLeft;
	public bool TimerOn;

	public TextMeshProUGUI TimerText;

	private void Update()
	{
		if (TimerOn)
		{
			if (TimeLeft > 0)
			{
				TimeLeft -= Time.deltaTime;
				updateTimer(TimeLeft);
			}
			else
			{
				TimeLeft = 0f;
				TimerText.text = "00:00";
			}
		}
	}


	void updateTimer(float currentTime)
	{
		float minutes = Mathf.FloorToInt(currentTime / 60);
		float seconds = Mathf.FloorToInt(currentTime % 60);

		TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
	}
}