using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< Updated upstream
   public void Playgame () 
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

=======
   public void PlayGame ()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
>>>>>>> Stashed changes
   public void QuitGame ()
   {
    Application.Quit();
   }
}
