using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 direction = Vector3.forward;
    public LayerMask affectedLayers;

    private void OnTriggerStay(Collider other)
    {
        if ((affectedLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            Vector3 movement = transform.TransformDirection(direction) * speed * Time.deltaTime;

            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.Move(movement);
            }
            else
            {
                other.transform.position += movement;
            }
        }
    }
}