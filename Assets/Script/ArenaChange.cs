using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaChange : MonoBehaviour
{

    public bool unlocked = false;
    void OnTriggerEnter(Collider other)
    {

        if (unlocked) {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("Arena");
            }
        }
        
    }
}
