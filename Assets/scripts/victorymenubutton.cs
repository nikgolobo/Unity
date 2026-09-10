using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}