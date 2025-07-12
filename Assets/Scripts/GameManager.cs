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

  // ����������� ��� ��������� Start � ����
  public void StartGame() {
    OnGameStart?.Invoke();
  }

  // ����������� ��� ������� � ����������
  public void TriggerGameOver() {
    OnGameOver?.Invoke();
  }

  // ���������� ����
  public void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  // ���������� � ������� ����
  public void ExitToMenu() {
    SceneManager.LoadScene("MainMenu");
  }
}