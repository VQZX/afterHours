using UnityEngine;
using UnityEngine.SceneManagement;

namespace AfterHours.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public string main = "VidTest";

        public string menu = "Menu";

        public string credits = "Credits";


        public void LoadScene (string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void LoadMain ()
        {
            LoadScene(main);
        }

        public void LoadMenu ()
        {
            LoadScene(menu);
        }

        public void LoadCredits ()
        {
            LoadScene(credits);
        }

        public void Exit ()
        {
            Application.Quit();
        }
    }
}
