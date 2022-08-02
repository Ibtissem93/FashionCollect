using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    
    Doll doll;
   
    public GameObject Win;
    public GameObject Loose;
    public Animator DollAnim;
    private void Start()
    {
       
        doll = Doll.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameOver();

        }
    }


    public void GameOver()
    {
        doll.StopDoll();
        Loose.SetActive(true);
    }

}
