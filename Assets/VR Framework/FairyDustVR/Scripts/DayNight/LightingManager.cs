using UnityEngine;

//while in editor/not in game the methods will be running
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;


    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24);
        }
    }


    private void UpdateLighting(float _timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColour.Evaluate(_timePercent);
        RenderSettings.fogColor = preset.fogColour.Evaluate(_timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionColour.Evaluate(_timePercent);
            
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((_timePercent * 360f) - 90f, 170f, 0));
        }
    }
    
    
    /// <summary>
    /// Try to find a directional light to use if we haven't set one yet.
    /// </summary>
    private void OnValidate()
    {
        if (directionalLight != null)
        {
            return;
        }

        //Search for the lighting sun
        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        //Search scene for light that is directional
        {
            Light[] lights = FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
