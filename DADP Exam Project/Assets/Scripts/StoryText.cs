using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryText : MonoBehaviour
{
    public GameObject storyPanel;

    public TextMeshProUGUI hq1;
    public TextMeshProUGUI hq2;
    public TextMeshProUGUI hq3;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;

    public GameObject nextButton;
    public GameObject nextButton2;

    private void Start()
    {
        storyPanel.SetActive(true);

        StartCoroutine(startStory());
    }

    public IEnumerator startStory()
    {
        hq1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        player1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);


        hq2.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);


        player2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        nextButton.gameObject.SetActive(true);
    }

    public void buttenEndStory()
    {
        StartCoroutine(endStory());
    }

    public IEnumerator endStory()
    {
        hq1.gameObject.SetActive(false);
        player1.gameObject.SetActive(false);
        hq2.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        hq3.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);

        player3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        nextButton2.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
