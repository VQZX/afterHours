using Flusk;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AfterHours
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        protected SceneList list;
    
        //TODO: will need to test the scene load times testing
        public void LoadScene(string scene)
        {
            Debug.Log("Load Scene "+scene);
            if (list.Contains(scene))
            {
                SceneManager.LoadScene(scene);
            }
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
