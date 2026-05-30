using UnityEngine;
using UnityEngine.UI;

public class CollectionBar : MonoBehaviour
{
    private Image fillImage;
    private FlowerScript flowerScript;

    private void Start()
    {
        // Get the Image component on this object
        fillImage = GetComponent<Image>();

        Debug.Log("fillImage: " + fillImage);

        // Get the FlowerScript from the parent
        flowerScript = GetComponentInParent<FlowerScript>();

        Debug.Log("flowerScript: " + flowerScript);

        if (fillImage == null)
        {
            Debug.LogError("CollectionBar must have an Image component!");
        }

        if (flowerScript == null)
        {
            Debug.LogError("CollectionBar must be a child of an object with FlowerScript!");
        }
    }

    private void Update()
    {
        if (flowerScript != null && fillImage != null)
        {
            //Debug.Log("Collection Progress: " + flowerScript.GetCollectionProgress());
            // Update the fill amount based on collection progress
            fillImage.fillAmount = flowerScript.GetCollectionProgress();
        }
    }
}
