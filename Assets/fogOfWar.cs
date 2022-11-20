using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fogOfWar : MonoBehaviour
{
    // Start is called before the first frame update
      // Component for the mask
    public RawImage rawImage;
    // Place to draw our revealing smudges
    public RenderTexture targetRender;
    public RectTransform targetImage;

    Texture2D texture;

    private Camera main;
    private Vector2 localPoint;

    public int CircleRadius = 5;
    
    void Start()
    {
        texture = new Texture2D (targetRender.width, targetRender.height);
        var clearColors = new Color[targetRender.width * targetRender.height];
        
        // clear initial image
        for (int i = 0; i < clearColors.Length; i++)
        {
            clearColors[i] = Color.clear;
        }
        texture.SetPixels(0,0,targetRender.width, targetRender.height, clearColors);
        texture.Apply();
        
        rawImage.texture = texture;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            var inputPos = Input.mousePosition;

            // Convert mouse point to our target map-revealing position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(targetImage, inputPos, main, out localPoint);
            
            // set our current render texture for drawing
            RenderTexture.active = targetRender;

            // Draw circle to reveal content
            int xPos = Mathf.RoundToInt((localPoint.x / targetImage.sizeDelta.x) * (float)targetRender.width);
            int yPos = Mathf.RoundToInt((localPoint.y / targetImage.sizeDelta.y) * (float)targetRender.height);
            
            float circle = 2 * Mathf.PI * 5;
            
            for (int i = 0; i < CircleRadius*2; i++)
            {
                for (int j = 0; j < CircleRadius*2; j++)
                {
                    int targetX = i - CircleRadius;
                    int targetY = j - CircleRadius;

                    float distance = Mathf.Sqrt((targetX * targetX) + (targetY * targetY));
                    if (distance < CircleRadius)
                    {
                        texture.SetPixel(xPos+targetX, yPos+targetY, Color.black);
                    }
                }    
            }
            
            // Don't forget to apply the result
            texture.Apply();

            RenderTexture.active = null;
        }
    }
}
