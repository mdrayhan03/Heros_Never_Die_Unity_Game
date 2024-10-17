using UnityEngine;
using UnityEngine.SceneManagement;

public class HTPButtonHandler : MonoBehaviour
{
    // This function will be triggered when the button is clicked
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        // Add any logic here, e.g., load a new scene
        SceneManager.LoadScene("HTPScene");
    }
}