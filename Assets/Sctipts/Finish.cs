using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string SceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(string.IsNullOrEmpty(SceneName)) { SceneName = "MainHub"; }
            SceneManager.LoadScene(SceneName);
        }
    }
}
