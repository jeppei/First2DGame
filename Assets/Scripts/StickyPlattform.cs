using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlattform : MonoBehaviour
{
    /* If the gameobject has two Box Collider 2D components then 
     * the component that has "Is Trigger" set to true will use 
     *  - OnTriggerEnter2D
     *  - OnTriggerExit2D
     * and the component that has "Is Trigger" set to false will use
     *  - OnCollisionEnter2D
     *  - OnCollisionExit2D
     */

    private void OnCollisionEnter2D(Collision2D collision) { }
    private void OnCollisionExit2D(Collision2D collision) { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
