using UnityEngine;

public class Collectible : MonoBehaviour {
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      // Повідомляємо менеджер про збір
      CollectibleManager.Instance.CollectCoin();
      // Вимикаємо об’єкт (або анімація зникнення)
      gameObject.SetActive(false);
    }
  }
}