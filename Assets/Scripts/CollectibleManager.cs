using System;
using UnityEngine;

public class CollectibleManager : MonoBehaviour {
  public static CollectibleManager Instance { get; private set; }

  public event Action<int> OnCoinCountChanged;

  private int coinCount = 0;

  private void Awake() {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  // ����������� ������� ����, ���� �������� ����� �������
  public void CollectCoin() {
    coinCount++;
    OnCoinCountChanged?.Invoke(coinCount);
  }

  // (�� �������) �������� �������� �������
  public int GetCoinCount() => coinCount;
}