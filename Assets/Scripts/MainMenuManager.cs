using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    Application.Quit();
  }
}