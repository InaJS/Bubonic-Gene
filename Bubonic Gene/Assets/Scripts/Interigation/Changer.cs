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

    [SerializeField] private RawImage MainCh;
    [SerializeField] private RawImage TargetCh;


    private void Start()
    {
        Character = 0;

        Index = 0;

        NChoices = 0;
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
                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartDialouge(Target, Index);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;
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
                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartQuestion(Target, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;
                    Character = 0;
                    Index++;
                    NChoices++;
                }
            }
            
            else if (Number <= Index)
            {
                Index = 0;
                FindObjectOfType<Manager>().ShowQuestions();
            }
        }

        else if (Questioning == 2)
        {
            print(Character);
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
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartChoosing(Target, Index, NQuest);
                    MainCh.GetComponent<RawImage>().color = Color.gray;
                    TargetCh.GetComponent<RawImage>().color = Color.white;
                    Character = 0;
                    Index++;
                    NChoices++;
                }
            }

            else if (Number <= Index )
            {
                Index = 0;
                FindObjectOfType<Manager>().ShowChoices();
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

    public void SetChoice(int C, int q, char k)
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
            TriggerDialouge();
        }
    }
}
