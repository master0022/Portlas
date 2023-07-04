using UnityEngine;

public class PortalableObject : MonoBehaviour
{
    public delegate void HasTeleportedHandler(Portal sender, Portal destination, Vector3 newPosition, Quaternion newRotation);
    public event HasTeleportedHandler HasTeleported;

    public delegate void HasTeleportedViewHandler(PortalWindow sender, PortalWindow destination, Vector3 newPosition, Quaternion newRotation);
    public event HasTeleportedViewHandler HasViewTeleported;

    public void OnHasTeleported(Portal sender, Portal destination, Vector3 newPosition, Quaternion newRotation)
    {
        HasTeleported?.Invoke(sender, destination, newPosition, newRotation);
    }

    public void OnHasTeleported(PortalWindow sender, PortalWindow destination, Vector3 newPosition, Quaternion newRotation)
    {
        HasViewTeleported?.Invoke(sender, destination, newPosition, newRotation);
    }
}