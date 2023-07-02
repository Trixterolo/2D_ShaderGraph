using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelationEffect : MonoBehaviour
{
    public float pixelationAmount = 1000;
    public float pixelationTarget;
    public float pixelationSpeed = 10;

    public float pixelValue = 10;
    public float originalValue = 5000;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        pixelationTarget = originalValue;

        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        pixelationAmount = Mathf.Lerp(pixelationAmount, pixelationTarget, pixelationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
        {
            pixelationTarget = pixelValue;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            pixelationTarget = originalValue;
        }

        mat.SetFloat("_PixelationAmount", pixelationAmount);//apply the change in shader
        
    }
}
