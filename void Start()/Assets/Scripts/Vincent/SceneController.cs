using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _i;
    public static SceneController i {
        get {
            if (_i == null) {
                _i = FindObjectOfType<SceneController>();
            }
            return _i;
        }
    }

    public void LoadScene(int i) {
        SceneManager.LoadScene(i);
    }

    public void LoadSceneBySec(int i) {
        TransitionScreen.PlayTransitionScreen();
        StartCoroutine(waitForSec(i));
    }

    IEnumerator waitForSec(int i) {
        yield return new WaitForSeconds(1.5f);
        LoadScene(i);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
