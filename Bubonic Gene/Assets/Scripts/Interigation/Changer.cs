using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartDialouge(Target, Index);
                    Character = 0;
                    Index++;
                    NChoices++;
                }

            }
            else if (UntilChoices == NChoices)
            {
                FindObjectOfType<Manager>().StartChoices();
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
                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartQuestion(Target, Index, NQuest);
                    Character = 0;
                    Index++;
                    NChoices++;
                }
            }
            
            else if (Number <= Index)
            {
                Index = 0;
                FindObjectOfType<Manager>().StartChoices();
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
                    FindObjectOfType<Manager>().StartQuestion(Target, Index, NQuest);
                    Character++;
                }

                else if (Character == 1)
                {
                    FindObjectOfType<Manager>().StartQuestion(Target, Index, NQuest);
                    Character = 0;
                    Index++;
                    NChoices++;
                }
            }

            else if (Number <= Index )
            {
                Index = 0;
                FindObjectOfType<Manager>().StartChoices();
            }
        }

    }

    public void DialougeEnd()
    {
        Character = 0;

        Index = 0;
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
            ChoiceN = C;
            TriggerDialouge();
        }
    }
}
