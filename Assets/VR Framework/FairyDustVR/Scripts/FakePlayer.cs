using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    private float speed = 2f;
    private int colliderIndex;
    [SerializeField] private GameObject[] flames;

    // Start is called before the first frame update
    void Start()
    {
        flames[0].gameObject.SetActive(false);
        flames[1].gameObject.SetActive(false);
        flames[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Colliding with triggers");

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
