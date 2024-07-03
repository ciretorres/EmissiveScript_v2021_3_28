using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * TODO: describir clase EmmisiveScriptV2
 */
public class EmissiveScriptV2 : MonoBehaviour
{
    // An instance of the material object
    [SerializeField] private Material emissiveMaterial;
    // The object that renders the material
    [SerializeField] private Renderer objectToChange;
    // The color of the emission material
    private Color color;
    // The intensity of the color
    public float intensity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the material renderered from object component
        emissiveMaterial = objectToChange.GetComponent<Renderer>().material;
        // Get the emission color of the material instance
        color = emissiveMaterial.GetColor("_EmissionColor");
    }

    private void Update()
    {
        setIntensityColor();
    }

    private void setIntensityColor()
    {
        emissiveMaterial.SetColor("_EmissionColor", color * intensity);
    }
    /*
     * TODO: incrementar el valor mediante un evento de interfaz
     */
    private void increaseIntensity()
    {
        if (intensity == 20)
        {
            intensity = 20;
        }
        else
        {
            intensity += 1;
        }
        setIntensityColor();
    }
    /*
     * TODO: reducir el valor mediante un evento de interfaz
     */
    private void decreaseIntensity()
    {
        if (intensity == 0)
        {
            intensity = 0;
        }
        else
        {
            intensity -= 1;
        }
        setIntensityColor();
    }

    private void OnDestroy()
    {
        Destroy(emissiveMaterial);
    }

}
