using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform teleport;

    public void TeleportToPoint()
    {
        player.transform.position = new Vector3(200f, 1f, 250f);
        player.transform.rotation = teleport.transform.rotation;
    }
}
