using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
  [Header("HUD")]
  [SerializeField] private TextMeshProUGUI coinText;

  [Header("Screens")]
  [SerializeField] private GameObject gameOverPanel;
  [SerializeField] private Button retryButton;
  [SerializeField] private Button exitButton;

  private void OnEnable() {
    CollectibleManager.Instance.OnCoinCountChanged += UpdateCoinUI;
    GameManager.Instance.OnGameOver += ShowGameOverScreen;
    retryButton.onClick.AddListener(GameManager.Instance.Retry);
    exitButton.onClick.AddListener(GameManager.Instance.ExitToMenu);
  }

  private void OnDisable() {
    CollectibleManager.Instance.OnCoinCountChanged -= UpdateCoinUI;
    GameManager.Instance.OnGameOver -= ShowGameOverScreen;
    retryButton.onClick.RemoveAllListeners();
    exitButton.onClick.RemoveAllListeners();
  }

  private void Start() {
    coinText.text = "0";
    gameOverPanel.SetActive(false);
  }

  private void UpdateCoinUI(int count) {
    coinText.text = count.ToString();
  }

  private void ShowGameOverScreen() {
    gameOverPanel.SetActive(true);
  }
}