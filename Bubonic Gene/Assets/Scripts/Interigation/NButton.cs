using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NButton : MonoBehaviour
{
    [SerializeField] private int Choices;

    [SerializeField] private int Question;

    [SerializeField] private char Kind;

    [SerializeField] private char Mood;

    [SerializeField] private GameObject Changer;

    public void ConvCon()
    {
        Changer.GetComponent<Changer>().SetChoice(Choices, Question, Kind, Mood);
    }
}
