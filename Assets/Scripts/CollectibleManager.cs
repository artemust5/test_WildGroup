using System;
using UnityEngine;

public class CollectibleManager : MonoBehaviour {
  public static CollectibleManager Instance { get; private set; }

  public event Action<int> OnCoinCountChanged;

  private int coinCount = 0;

  /// <summary>
  /// Ensures singleton instance for global access.
  /// Destroys duplicate managers.
  /// </summary>
  private void Awake() {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  /// <summary>
  /// Adds one coin and notifies listeners of updated count.
  /// </summary>
  public void CollectCoin() {
    coinCount++;
    OnCoinCountChanged?.Invoke(coinCount);
  }
}