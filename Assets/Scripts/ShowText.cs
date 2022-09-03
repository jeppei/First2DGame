using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{

    [SerializeField] private float buttonMovement = 15f;
    [SerializeField] private SpriteRenderer text;
    private bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPressed) return;
        text.enabled = true;
        transform.position -= Time.fixedDeltaTime * transform.up * buttonMovement;
        isPressed = true;
    }
}
