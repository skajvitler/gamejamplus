using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int health = 100;

	public GameObject deathEffect;

    private SpriteRenderer spriteRenderer;

    private float duration = 1f;
    private bool died = false;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator GrayscaleRoutine(float duration, bool isGrayscale)
    {
        float time = 0;
        while (duration > time)
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

    public void SetGrayscale(float amount)
    {
        spriteRenderer.material.SetFloat("_GrayscaleAmount", amount);
    }

    public void TakeDamage(int damage)
	{
        if (!died)
        {
            StartCoroutine(GrayscaleRoutine(duration, true));
        }
		    
		health -= damage;

		if (health <= 0)
		{
            Die();
            


        }
	}

	void Die()
	{
        died = true;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        SetGrayscale(0);

    }

}