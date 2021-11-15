using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] private Text Name;
    [SerializeField] private Text Words;

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
        Conversastion.enabled = true;
        sentences.Clear();

        Name.text = Character.name;

        if(NQuest == 1)
            Words.text = Character.QAnsers1[Index];


        if (NQuest == 2)
            Words.text = Character.QAnsers2[Index];


        if (NQuest == 3)
            Words.text = Character.QAnsers3[Index];


        if (NQuest == 4)
            Words.text = Character.QAnsers4[Index];
    }

    public void StartChoosing(Dialouge Character, int Index, int NQuest)
    {
        Questions.enabled = false;
        Conversastion.enabled = true;
        sentences.Clear();

        Name.text = Character.name;

        if (NQuest == 1)
            Words.text = Character.choice1[Index];


        if (NQuest == 2)
            Words.text = Character.choice2[Index];


        if (NQuest == 3)
            Words.text = Character.choice3[Index];


        if (NQuest == 4)
            Words.text = Character.choice4[Index];
    }

    public void StartChoices()
    {
        Questions.enabled = true;
        Conversastion.enabled = false;
    }
}
