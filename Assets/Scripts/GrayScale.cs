using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScale : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float duration = 1f;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator GrayscaleRoutine(float duration, bool isGrayscale)
    {
        float time = 0;
        while(duration > time)
        {
            float durationFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = ratio;
            SetGrayscale(grayAmount);
            time += durationFrame;
            yield return null;
        }
        SetGrayscale(1);
    }

    public void SetGrayscale(float amount = 1)
    {
        spriteRenderer.material.SetFloat("_GrayscaleAmount", amount);
    }
}
