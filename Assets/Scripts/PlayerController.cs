using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private PortalableObject portalableObject;

    public Transform playerCamera;
    private float verticalRotationAbsolute;

    public float moveSpeed = 5;
    public float turnSpeed = 5;

    private float turnRotation;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        portalableObject = GetComponent<PortalableObject>();
        portalableObject.HasTeleported += PortalableObjectOnHasTeleported;
        playerCamera = Camera.main.transform;
    }

    private void PortalableObjectOnHasTeleported(Portal sender, Portal destination, Vector3 newposition, Quaternion newrotation)
    {
        // For character controller to update

        Physics.SyncTransforms();
    }

    private void FixedUpdate()
    {
        // Turn player

        transform.Rotate(Vector3.up * turnRotation * turnSpeed);
        turnRotation = 0; // Consume variable

        // Turn player (up/down)

        playerCamera.localRotation = Quaternion.Euler(verticalRotationAbsolute, 0, 0);

        // Move playerw

        characterController.SimpleMove(
            transform.forward * Input.GetAxis("Vertical") * moveSpeed +
            transform.right * Input.GetAxis("Horizontal") * moveSpeed);
    }

    private void Update()
    {
        turnRotation += Input.GetAxis("Mouse X");

        verticalRotationAbsolute += Input.GetAxis("Mouse Y") * -turnSpeed;
        verticalRotationAbsolute = Mathf.Clamp(verticalRotationAbsolute, -89, 89);
    }

    private void OnDestroy()
    {
        portalableObject.HasTeleported -= PortalableObjectOnHasTeleported;
    }
}