using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
  private const float FALL_THRESHOLD = -1f;

  [Header("Movement Settings")]
  [SerializeField] private float forwardSpeed = 5f;
  [SerializeField] private float strafeSpeed = 3f;

  [Header("Animator")]
  [SerializeField] private Animator _animator;

  [Header("Particles")]
  [SerializeField] private ParticleSystem _death;

  [Header("Model")]
  [SerializeField] private GameObject _model;

  [Header("Sounds")]
  [SerializeField] private AudioSource[] _deathSounds;
  [SerializeField] private AudioSource _bacgroundSound;

  private bool isGameOver = false;

  /// <summary>
  /// Subscribes to game over event from GameManager.
  /// </summary>
  private void Start() {
    if (GameManager.Instance != null)
      GameManager.Instance.OnGameOver += OnGameOver;
    else
      Debug.LogError("GameManager.Instance is null in PlayerController");
  }

  /// <summary>
  /// Unsubscribes from game over event to avoid memory leaks.
  /// </summary>
  private void OnDisable() {
    if (GameManager.Instance != null)
      GameManager.Instance.OnGameOver -= OnGameOver;
  }

  /// <summary>
  /// Handles player movement, animation and fall detection.
  /// </summary>
  private void Update() {
    if (isGameOver) return;

    HandleMovement();
    UpdateAnimations();

    if (transform.position.y < FALL_THRESHOLD)
      GameManager.Instance?.TriggerGameOver();
  }

  /// <summary>
  /// Applies movement based on horizontal input and forward speed.
  /// </summary>
  private void HandleMovement() {
    float h = Input.GetAxis("Horizontal");
    float forwardModifier = 1f - Mathf.Abs(h) * 0.5f;
    float adjustedForwardSpeed = forwardSpeed * forwardModifier;
    Vector3 move = Vector3.forward * adjustedForwardSpeed + Vector3.right * h * strafeSpeed;
    transform.Translate(move * Time.deltaTime, Space.World);
  }

  /// <summary>
  /// Updates animator parameters according to input and movement.
  /// </summary>
  private void UpdateAnimations() {
    if (_animator == null) return;

    float h = Input.GetAxis("Horizontal");
    float forwardModifier = 1f - Mathf.Abs(h) * 0.5f;
    float adjustedForwardSpeed = forwardSpeed * forwardModifier;

    _animator.SetFloat("Speed", adjustedForwardSpeed, 0.1f, Time.deltaTime);
    _animator.SetFloat("Strafe", h, 0.1f, Time.deltaTime);
  }

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Obstacle"))
      GameManager.Instance?.TriggerGameOver();
  }

  /// <summary>
  /// Handles visual and audio effects when the game ends.
  /// </summary>
  private void OnGameOver() {
    isGameOver = true;

    _death?.Play();
    _bacgroundSound?.Stop();

    foreach (var source in _deathSounds) {
      source?.Play();
    }

    if (_model != null)
      Destroy(_model);
  }
}