using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  public event Action OnGameStart;
  public event Action OnGameOver;

  /// <summary>
  /// Ensures a single instance and destroys duplicates.
  /// </summary>
  private void Awake() {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  /// <summary>
  /// Invokes the game start event for listeners.
  /// </summary>
  public void StartGame() {
    OnGameStart?.Invoke();
  }

  /// <summary>
  /// Triggers the game over event for listeners.
  /// </summary>
  public void TriggerGameOver() {
    OnGameOver?.Invoke();
  }

  /// <summary>
  /// Reloads the current active scene.
  /// </summary>
  public void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void ExitToMenu() {
    SceneManager.LoadScene("MainMenu");
  }
}