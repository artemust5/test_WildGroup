using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  public event Action OnGameStart;
  public event Action OnGameOver;

  private void Awake() {
    // Singleton
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  // Викликається при натисканні Start у меню
  public void StartGame() {
    OnGameStart?.Invoke();
  }

  // Викликається при зіткненні з перешкодою
  public void TriggerGameOver() {
    OnGameOver?.Invoke();
  }

  // Перезапуск рівня
  public void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  // Повернення в головне меню
  public void ExitToMenu() {
    SceneManager.LoadScene("MainMenu");
  }
}