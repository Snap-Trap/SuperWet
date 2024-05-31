using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanger : MonoBehaviour
{
    public int requiredGrabs = 5;
    private int currentGrabs = 0;

    private void OnEnable()
    {
        GrabbableObject.OnObjectGrabbed += HandleObjectGrabbed;
    }

    private void OnDisable()
    {
        GrabbableObject.OnObjectGrabbed -= HandleObjectGrabbed;
    }

    private void HandleObjectGrabbed()
    {
        currentGrabs++;

        if (currentGrabs >= requiredGrabs)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Assuming you have a next scene set in your build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
