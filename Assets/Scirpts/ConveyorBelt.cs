using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 direction = Vector3.forward;
    public Vector3 detectionSize = new Vector3(0.9f, 0.5f, 0.9f);
    public Vector3 offset = new Vector3(0, 0.6f, 0);

    private void Update()
    {
        Vector3 worldDirection = transform.TransformDirection(direction.normalized);
        Collider[] colliders = Physics.OverlapBox(transform.position + transform.TransformDirection(offset), detectionSize / 2, transform.rotation);

        foreach (Collider col in colliders)
        {
            if (col.gameObject == gameObject) continue;

            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                CharacterController cc = col.GetComponent<CharacterController>();
                if (cc != null)
                {
                    cc.Move(worldDirection * speed * Time.fixedDeltaTime);
                }
            }
            else
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null && !rb.isKinematic)
                {
                    Vector3 targetVelocity = worldDirection * speed;
                    rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(offset, detectionSize);
    }
}