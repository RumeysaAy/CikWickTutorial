using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private Transform _playerVisualTransform;

    [Header("Settings")]
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Vector3 viewDirection
        = _playerTransform.position - new Vector3(transform.position.x, _playerTransform.position.y, transform.position.z);

        // karakterin yönü baktığım yöne eşitlenir
        _orientationTransform.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = _orientationTransform.forward * verticalInput + _orientationTransform.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
            // Slerp: rotasyon için, Lerp: pozisyon için
            // karakterin görseli baktığım yöne döner
            _playerVisualTransform.forward = Vector3.Slerp(_playerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
    }

}
