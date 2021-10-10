using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float offset;

    private Vector2 startPosition;

    private float newXposition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offset);

        transform.position = startPosition + Vector2.right * newXposition;
    }
}

