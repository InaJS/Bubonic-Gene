using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCtrigger : MonoBehaviour
{

    [SerializeField] private GameObject E;
    [SerializeField] private GameObject Dialouge;
    private bool NoRepeat = false;

    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            if (Input.GetKey("e"))
            {
                                
                if (NoRepeat == false) {

                    Dialouge.GetComponent<Manager>().StartConversastion();
        
                    NoRepeat = true;

                }
                
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NoRepeat = false;
            E.SetActive(false);
        }
    }
}
