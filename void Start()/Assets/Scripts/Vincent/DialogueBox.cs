using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class Sentence {
    [TextArea(2,10)]
    public string content;
    public float duration;
}

public class DialogueBox : MonoBehaviour
{

    public List<Sentence> sentences;
    private bool isTalking;
    private TextMeshPro text;
    private int currentSentenceIndex = 0;

    public bool isControllingByDuration;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (isTalking) {
            ShowText();
        }
    }

    private void OnEnable()
    {
        if (isControllingByDuration)
        {
            isTalking = true;
        }
        else {
            text.text = sentences[currentSentenceIndex].content;
        }
    }

    private void OnDisable()
    {
        if (isControllingByDuration)
        {
            isTalking = false;
        }
        else {
            if (currentSentenceIndex < sentences.Count - 1) {
                currentSentenceIndex += 1;
            }
        }
    }

    public void ShowText() {
        text.text = sentences[currentSentenceIndex].content;
        if (currentSentenceIndex < sentences.Count - 1) {
            if (sentences[currentSentenceIndex].duration > 0)
            {
                sentences[currentSentenceIndex].duration -= Time.deltaTime;
            }
            else
            {
                currentSentenceIndex += 1;
            }
        }
    }
}
