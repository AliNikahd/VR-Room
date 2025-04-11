using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagnetHapticTrigger : MonoBehaviour
{
    public XRBaseController controller; // Reference to the controller
    public float hapticStrength = 0.5f;
    public float hapticDuration = 0.1f;
    public float maxDistance = 1.5f;

    void Update()
    {
        if (controller == null) return;

        float distance = Vector3.Distance(controller.transform.position, transform.position);

        if (distance <= maxDistance)
        {
            float intensity = Mathf.Lerp(hapticStrength, 0, distance / maxDistance);
            controller.SendHapticImpulse(intensity, hapticDuration);
        }
    }
}