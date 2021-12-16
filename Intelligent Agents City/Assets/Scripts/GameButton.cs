using UnityEngine;
using UnityEngine.SceneManagement;


public class GameButton : MonoBehaviour
{
    bool isPause = false;
    //Μέθοδος με την οποία κάνουμε reload το παιχνίδι.
    public void ReloadGame()
    {
      Application.LoadLevel(Application.loadedLevel);
      Time.timeScale = 1;
      isPause = false;
    }

    //Μεθοδος με την οποία επιστρέφουμε στο αρχικό μενού.
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //μεθοδος για να σταματά το παιχνίδι
    public void PauseGame()
    {
       
        if (isPause) {
            Time.timeScale = 1;
            isPause = false;
        }
        else {
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
