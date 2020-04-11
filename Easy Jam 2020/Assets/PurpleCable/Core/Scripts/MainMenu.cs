using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PurpleCable
{
    public class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        public void StartGame()
        {
            LoadScene("Main");
        }

        public void ShowCredits()
        {
            LoadScene("Credits");
        }

        public void ShowControls()
        {
            LoadScene("Controls");
        }

        public void ShowSettings()
        {
            LoadScene("Settings");
        }

        public void GoToMenu()
        {
            LoadScene("Menu");
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(GoToScene(sceneName));
        }

        public static IEnumerator GoToScene(string sceneName)
        {
            FadeInOut.FadeOut();

            while (FadeInOut.IsFading)
                yield return null;

            SceneManager.LoadScene(sceneName);
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            FadeInOut.FadeIn();
        }
    }
}
