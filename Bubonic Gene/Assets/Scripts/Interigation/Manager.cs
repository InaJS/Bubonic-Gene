using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] private Text Name;
    [SerializeField] private Text Words;

    private string FullSentence;

    [SerializeField] private Canvas MainView;
    [SerializeField] private Canvas Questions;
    [SerializeField] private Canvas Choice;
    [SerializeField] private Canvas Conversastion;

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Changer;

    private void Start()
    {
        
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge Character, int Index)
    {
        sentences.Clear();
        Name.text = Character.name;

        FullSentence = Character.sentences[Index];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(FullSentence));
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
            FullSentence = Character.QAnsers1[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(FullSentence));
        }

        if (NQuest == 2)
        {
            Words.text = Character.QAnsers2[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

        if (NQuest == 3)
        { 
            Words.text = Character.QAnsers3[Index];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Words.text));
        }

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
        Questions.enabled = false;
        Conversastion.enabled = true;
        Choice.enabled = false;

        Changer.GetComponent<Changer>().DialougeEnd();
        MainView.enabled = false;
        Player.GetComponent<CharacterController>().enabled = true;
        Player.GetComponent<PlayerMovement3D>().enabled = true;
        //Menu.SetActive(true);
    }

    public void StartConversastion()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Player.GetComponent<PlayerMovement3D>().enabled = false;
        MainView.enabled = true;
        //Menu.SetActive(false);

        Changer.GetComponent<Changer>().TriggerDialouge();
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
