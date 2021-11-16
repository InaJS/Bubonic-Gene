using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] private Text Name;
    [SerializeField] private Text Words;

    [SerializeField] private GameObject MainView;
    [SerializeField] private Canvas Questions;
    [SerializeField] private Canvas Choice;
    [SerializeField] private Canvas Conversastion;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge Character, int Index)
    {
        sentences.Clear();

        Name.text = Character.name;

        Words.text = Character.sentences[Index];

    }

    public void StartQuestion(Dialouge Character, int Index, int NQuest)
    {
        Questions.enabled = false;
        Choice.enabled = false;
        Conversastion.enabled = true;
        sentences.Clear();

        Name.text = Character.name;

        if (NQuest == 1)
        {
            Words.text = Character.QAnsers1[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 2)
        {
            Words.text = Character.QAnsers2[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 3)
            ShowChoices();


        if (NQuest == 4)
        { 
            Words.text = Character.QAnsers4[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }
    }

    public void StartChoosing(Dialouge Character, int Index, int NQuest)
    {
       
        Questions.enabled = false;
        Choice.enabled = false;
        Conversastion.enabled = true;
        sentences.Clear();

        Name.text = Character.name;

        if (NQuest == 1)
        { 
            Words.text = Character.choice1[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 2)
        { 
            Words.text = Character.choice2[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 3)
        { 
            Words.text = Character.choice3[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 4)
        {
            Words.text = Character.choice4[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        
        Words.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            Words.text += letter;
            yield return new WaitForSecondsRealtime(0.015f);
        }
    }

    public void ShowQuestions()
    {
        Questions.enabled = true;
        Conversastion.enabled = false;
        Choice.enabled = false;
    }

    public void ShowChoices()
    {
        Questions.enabled = false;
        Conversastion.enabled = false;
        Choice.enabled = true;
    }

    public void EndConversastion()
    {
        MainView.SetActive(false);
    }

    public void StartConversastion()
    {
        MainView.SetActive(true);
    }
}
