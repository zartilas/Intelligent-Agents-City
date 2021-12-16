using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Μέθοδο για να ξεκινήσουμε το παιχνίδι
   public void PlayGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//μετακινούμαστε ενα Scene μπροστά
    }

    //Μέθοδος για το κουμπί play again στο τελευταίο Scene
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //μετακινούμαστε ενα Scene Πισω
        Application.LoadLevel(Application.loadedLevel);
    }

    //μέθοδος για την εξοδο μας από το παιχνίδι
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }    
}
