using UnityEngine;

public class WallCrackController : MonoBehaviour
{
    public float angleThreshold = 30f;
    public Material crackedMaterial;
    public Material brokenMaterial;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float angleDifference = Quaternion.Angle(initialRotation, transform.rotation);
        if (angleDifference > angleThreshold)
        {
            Material newMaterial = angleDifference > 2 * angleThreshold ? brokenMaterial : crackedMaterial;
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = newMaterial;
            }
        }
    }
}
