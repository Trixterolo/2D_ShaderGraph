using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveControl : MonoBehaviour
{
    public float dissolveAmount;
    public float dissolveSpeed;
    public bool isDissolving;

    [ColorUsage(true, true)] public Color fadeOutColor; //ColorUsage function enables HDR Intensity
    [ColorUsage(true, true)] public Color fadeInColor; //ColorUsage function enables HDR Intensity

    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isDissolving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            isDissolving = false;
        }

        if (isDissolving)
        {
            DissolveOut(dissolveSpeed, fadeOutColor);
        }
        else if(!isDissolving)
        {
            DissolveIn(dissolveSpeed, fadeInColor);
        }

        mat.SetFloat("_DissolveAmount", dissolveAmount);
    }

    public void DissolveOut(float speed, Color color)
    {
        mat.SetColor("_OutlineColor", color);
        if(dissolveAmount > -0.1) //higher than -0.1 to dissolve everything due to OutlineWidth Value!
        {
            dissolveAmount -= Time.deltaTime * speed;
        }
    }

    public void DissolveIn(float speed, Color color)
    {
        mat.SetColor("_OutlineColor", color);
        if (dissolveAmount < 1)
        {
            dissolveAmount += Time.deltaTime * speed;
        }
    }
}
