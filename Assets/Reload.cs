using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("PRESSED");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
