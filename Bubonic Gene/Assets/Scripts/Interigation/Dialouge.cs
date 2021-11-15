using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge : MonoBehaviour
{

    public string name;

    [TextArea(3,10)]
    public string[] sentences;

    [TextArea(3, 10)]
    public string[] choice1;

    [TextArea(3, 10)]
    public string[] choice2;

    [TextArea(3, 10)]
    public string[] choice3;

    [TextArea(3, 10)]
    public string[] choice4;

    [TextArea(3, 10)]
    public string[] QAnsers1;

    [TextArea(3, 10)]
    public string[] QAnsers2;

    [TextArea(3, 10)]
    public string[] QAnsers3;

    [TextArea(3, 10)]
    public string[] QAnsers4;
}
