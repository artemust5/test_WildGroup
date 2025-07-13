using UnityEngine;

public class Collectible : MonoBehaviour {
  [Header("Animator")]
  [SerializeField] private Animator _animator;
  [Header("Animator")]
  [SerializeField] private ParticleSystem _collect;
  [Header("Sounds")]
  [SerializeField] private AudioSource _collectSound;

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      CollectibleManager.Instance.CollectCoin();
      _collect.Play();
      _collectSound.Play();
      _animator.SetTrigger("IsCollect");
    }
  }
}