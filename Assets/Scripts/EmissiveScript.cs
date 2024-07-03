using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/*
 * TODO: describir clase EmmisiveScript
 */
public class EmissiveScript : MonoBehaviour
{
    /* An instance from the materials object set with an 
     * Universal Render Pipeline shader, the option Emission 
     * selected on true and white color HDR value**/
    [SerializeField] private Material emissiveMaterial;
    /* The 3d mesh render spehere or game object to change 
     * its material properties**/
    [SerializeField] private Renderer objectToChange;

    [SerializeField] private float defaultIntensity = 3.0f;
    [SerializeField] private TextMeshProUGUI emissionIntesityValue;
    [SerializeField] private Slider intesitySlider;

    // A texture or img optional to display in the game object
    [SerializeField] private Texture2D myTexture;

    // The color of light or emission property
    private Color color;
    // The intensity of light or emission property
    private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning only the material with all of its properties including Emission.
        emissiveMaterial = objectToChange.GetComponent<Renderer>().material;
        // Get the EmissionColor from shaders defined by user or ui in unity
        color = emissiveMaterial.GetColor("_EmissionColor");

        // Set the Intensity value of the text and slider at default.
        emissionIntesityValue.text = defaultIntensity.ToString("0");
        intesitySlider.value = defaultIntensity;

    }

    /* Disable the Emission option located at the Surfaces
     * Inputs in the Shaders properties of the material**/
    public void TurnEmissionOn() {
        emissiveMaterial.DisableKeyword("_EMISSION");
    }
    /* Enable the Emission option located at the Surfaces 
     * Inputs in the Shaders properties of the material**/
    public void TurnEmissionOff()
    {
        emissiveMaterial.EnableKeyword("_EMISSION");
    }
    /* Set the color of the emission material property object**/
    public void changeColor(string myColor)
    {
        switch(myColor)
        {
            case "Red":
                color = Color.red;
                intensity = 5.0f;
                emissiveMaterial.SetColor("_EmissionColor", color * intensity);
                break;
            case "Blue":
                color = Color.blue;
                intensity = 5.0f;
                emissiveMaterial.SetColor("_EmissionColor", color * intensity);
                break;
        }
    }
    /* Set the intensity value of the emission property
     * and updates the value in the text at the ui**/
    public void EmissionIntensity(float value)
    {
        emissiveMaterial.SetColor("_EmissionColor", color * value);
        emissionIntesityValue.text = value.ToString("0");
    }
    /* Set the texture of the material**/
    public void ChangeEmissionTexture()
    {
        emissiveMaterial.SetTexture("_EmissionMap", myTexture);
    }
    /* Destroy the instance of the material when you exit the scene**/
    private void OnDestroy()
    {
        Destroy(emissiveMaterial);
    }

}
