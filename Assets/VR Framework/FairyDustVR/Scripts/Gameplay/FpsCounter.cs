using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public TMP_Text fpsText;
    private int fps;

    // Update is called once per frame
    void Update()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        fpsText.text = "" + fps;
    }
}
