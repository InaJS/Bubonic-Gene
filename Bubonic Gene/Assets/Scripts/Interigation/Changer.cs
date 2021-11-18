using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changer : MonoBehaviour
{
    public Dialouge Main;

    public Dialouge Target;

    private static int Character;

    private static int Index;

    private static int NChoices;

    [SerializeField] private int UntilChoices;

    private static int WhatChoice;

    private static int Questioning;

    private static int NQuest;

    private static int ChoiceN;

    private static int Number;

    private int mood;

    [SerializeField] private RawImage MainCh;
    [SerializeField] private RawImage TargetCh;


    private void Start()
    {
        Character = 0;

        Index = 0;

        NChoices = 0;

        Target.Character.SetBool("Neutral", true);
    }

    public void TriggerDialouge()
    {

        if (Questioning == 0)
        {
            if (UntilChoices > NChoices)
            {
                if (Character == 0)
                {
                    FindObjectOfType<Manager>().StartDialouge(Main, Index);
                    MainCh.GetComponent<RawImage>().color = Color.white;
                    TargetCh.GetComponent<RawImage>().color = Color.gray;

                    Target.Character.SetBool("IsTalking", false);

                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartDialouge(Target, Index);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;

                    
                    Target.Character.SetBool("IsTalking", true);

                    Character = 0;
                    Index++;
                    NChoices++;
                }

            }
            else if (UntilChoices == NChoices)
            {
                FindObjectOfType<Manager>().ShowQuestions();
                Questioning = 1;
                NChoices = 0;

                Target.Character.SetBool("IsTalking", false);

                Index = 0;
            }
        }
        else if (Questioning == 1)
        {

            if (NQuest == 1)
                Number = Main.QAnsers1.Length;


            if (NQuest == 2)
                Number = Main.QAnsers2.Length;


            if (NQuest == 3)
                Number = Main.QAnsers3.Length;


            if (NQuest == 4)
                Number = Main.QAnsers4.Length;

            if (Number > Index)
            {
                if (Character == 0)
                {
                    FindObjectOfType<Manager>().StartQuestion(Main, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.white;
                    TargetCh.GetComponent<RawImage>().color = Color.gray;

                    Target.Character.SetBool("IsTalking", false);

                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartQuestion(Target, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;

                    Target.Character.SetBool("IsTalking", true);

                    Character = 0;
                    Index++;
                    NChoices++;
                }
            }
            
            else if (Number <= Index)
            {
                Target.Character.SetBool("IsTalking", false);
                Index = 0;
                FindObjectOfType<Manager>().ShowQuestions();
            }
        }

        else if (Questioning == 2)
        {
            
            if (NQuest == 1)
                Number = Main.choice1.Length;


            if (NQuest == 2)
                Number = Main.choice2.Length;


            if (NQuest == 3)
                Number = Main.choice3.Length;


            if (NQuest == 4)
                Number = Main.choice4.Length;

            if (Number > Index)
            {
                if (Character == 0)
                {
                    FindObjectOfType<Manager>().StartChoosing(Main, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.white;
                    TargetCh.GetComponent<RawImage>().color = Color.gray;
                    Character++;

                    Target.Character.SetBool("IsTalking", false);
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartChoosing(Target, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;
                    Character = 0;
                    Index++;
                    NChoices++;

                    Target.Character.SetBool("IsTalking", true);
                }
            }

            else if (Number <= Index )
            {
                Index = 0;
                FindObjectOfType<Manager>().ShowChoices();
                Target.Character.SetBool("IsTalking", false);
            }
        }

    }

    public void DialougeEnd()
    {
        Character = 0;

        Index = 0;
    }

    public void Prev()
    {
        if(Index == 0)
        {
            Index = 0;
            TriggerDialouge();
        }
        else if (Index > 0)
        {
            Index--;
            TriggerDialouge();
        }
        else
        {
            Index = 0;
            TriggerDialouge();
        }

    }

    public void SetChoice(int C, int q, char k, char m)
    {
        if (k == 'Q')
        {
            Questioning = 1;
            NQuest = q;
            TriggerDialouge();
        }

        if (k == 'C')
        {
            Questioning = 2;
            NQuest = C;

            if(m == 'N')
            {
                mood = 1;
            }
            if(m == 'A')
            {
                mood = 2;
            }
            if(m == 'H')
            {
                mood = 3;
            }

            SetMood(mood);
        }
    }

    private void SetMood(int a)
    {
        if (a == 1)
        {
            if(Target.Character.GetBool("Angry") == true || Target.Character.GetBool("Happy") == true)
            {
                Target.Character.SetBool("Happy", false);
                Target.Character.SetBool("Angry", false);
                Target.Character.SetBool("Neutral", true);
                TriggerDialouge();
            }
            else
            {
                Target.Character.SetBool("Neutral", true);
                TriggerDialouge();
            }   
        }

        if (a == 2)
        {
            if (Target.Character.GetBool("Neutral") == true || Target.Character.GetBool("Happy") == true)
            {
                Target.Character.SetBool("Happy", false);
                Target.Character.SetBool("Angry", true);
                Target.Character.SetBool("Neutral", false);
                TriggerDialouge();
            }
            else
            {
                Target.Character.SetBool("Angry", true);
                TriggerDialouge();
            }
        }
    }
}
