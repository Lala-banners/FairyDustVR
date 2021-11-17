using UnityEngine;

public class TriggerLamps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Collided with trigger");
        }
    }
}
