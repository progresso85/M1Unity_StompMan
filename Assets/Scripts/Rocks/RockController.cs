using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockController : MonoBehaviour
{
    public static int stompedRocksCount = 0; // Compteur de rochers écrasés

    [SerializeField] TextMeshProUGUI rockCounterText;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();

        if (player != null)
        {
            if (player.IsStomping() && player.transform.position.y > transform.position.y)
            {
                stompedRocksCount++; // Incrémenter le compteur
                

                Destroy(gameObject); // Détruire le rocher
            }
        }
    }

    private void Update()
    {
        // Vérifie que le Text est bien assigné pour éviter les erreurs
        if (rockCounterText != null)
        {
            rockCounterText.text = "Rochers écrasés : " + stompedRocksCount;
        }
    }
}


