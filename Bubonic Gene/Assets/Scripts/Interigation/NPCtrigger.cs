using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCtrigger : MonoBehaviour
{

    [SerializeField] private GameObject E;
    [SerializeField] private GameObject Dialouge;
    private bool NoRepeat = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            E.SetActive(true);

            if (Input.GetKey("e"))
            {
                print("Hello");

                //Dialouge.SetActive(true);


                if (NoRepeat == false) {

                    Dialouge.GetComponent<Manager>().StartConversastion();

                    //FindObjectOfType<Manager>().StartConversastion();
                    NoRepeat = true;

                }
                
            }




        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(false);
        }
    }
}
