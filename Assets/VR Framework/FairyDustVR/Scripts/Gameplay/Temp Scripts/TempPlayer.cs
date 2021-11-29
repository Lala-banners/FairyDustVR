using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    private int colliderIndex;
    [SerializeField] private GameObject[] flames;

    // Start is called before the first frame update
    void Start()
    {
        flames[0].gameObject.SetActive(false);
        flames[1].gameObject.SetActive(false);
        flames[2].gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Colliders")
        {
            flames[0].gameObject.SetActive(true);
        }
        
        if (other.gameObject.name == "Colliders (1)")
        {
            flames[1].gameObject.SetActive(true);
        }
        
        if (other.gameObject.name == "Colliders (2)")
        {
            flames[2].gameObject.SetActive(true);
        }
    }
}
