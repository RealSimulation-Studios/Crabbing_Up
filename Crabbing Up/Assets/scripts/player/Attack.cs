using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damageAmount = 10; // Der Schaden, der dem Gegner zugefügt wird

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Collider des Gegners getroffen wurde
        if (other.CompareTag("Enemy"))
        {
            // Rufe die Methode TakeDamage() auf dem Gegner auf, um Schaden zuzufügen
            other.GetComponent<simple_ai>().TakeDamage(damageAmount);
        }
    }
}
