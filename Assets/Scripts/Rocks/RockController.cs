using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();

        if(player != null)
        {
            if (player.IsStomping() && player.transform.position.y > transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
