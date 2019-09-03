using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (TextDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    private IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
