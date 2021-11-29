using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadFairyScene()
    {
        SceneManager.LoadScene("FairyCircle");
        gameObject.GetComponent<TempPlayer>().enabled = false;
    }
}
