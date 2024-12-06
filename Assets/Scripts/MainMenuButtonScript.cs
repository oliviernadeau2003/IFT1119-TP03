using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TP3");
    }
}
