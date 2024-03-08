using UnityEngine;

public class QuitGameOnKeyPress : MonoBehaviour
{
    void Update()
    {
        // Check if the 'U' key is pressed
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Quit the application
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}