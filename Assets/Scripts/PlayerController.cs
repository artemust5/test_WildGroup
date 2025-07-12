using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
  [Header("Movement Settings")]
  [SerializeField] private float forwardSpeed = 5f;
  [SerializeField] private float strafeSpeed = 3f;

  private bool isGameOver = false;

  private void Start() {
    GameManager.Instance.OnGameOver += OnGameOver;
  }

  private void OnDisable() {
    GameManager.Instance.OnGameOver -= OnGameOver;
  }

  private void Update() {
    if (isGameOver) return;

    float h = Input.GetAxis("Horizontal");
    Vector3 move = Vector3.forward * forwardSpeed + Vector3.right * h * strafeSpeed;
    transform.Translate(move * Time.deltaTime, Space.World);
  }

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Obstacle")) {
      GameManager.Instance.TriggerGameOver();
    }
  }

  private void OnGameOver() {
    isGameOver = true;
    // Тут можна зачинити анімацію, ефекти тощо
  }
}