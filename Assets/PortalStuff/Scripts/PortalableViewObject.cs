using UnityEngine;

public class PortalableViewObject : MonoBehaviour
{
    public delegate void HasTeleportedHandler(PortalWindow sender, PortalWindow destination, Vector3 newPosition, Quaternion newRotation);
    public event HasTeleportedHandler HasTeleported;

    public void OnHasTeleported(PortalWindow sender, PortalWindow destination, Vector3 newPosition, Quaternion newRotation)
    {
        HasTeleported?.Invoke(sender, destination, newPosition, newRotation);
    }
}