using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour {
  [SerializeField] private Button startButton;
  [SerializeField] private Button exitButton;

  private void OnEnable() {
    startButton.onClick.AddListener(OnStartClicked);
    exitButton.onClick.AddListener(OnExitClicked);
  }

  private void OnDisable() {
    startButton.onClick.RemoveListener(OnStartClicked);
    exitButton.onClick.RemoveListener(OnExitClicked);
  }

  private void OnStartClicked() {
    SceneManager.LoadScene("GameScene");
  }

  private void OnExitClicked() {
#if UNITY_EDITOR
    EditorApplication.isPlaying = false; 
#else
        Application.Quit();                   
#endif
  }
}