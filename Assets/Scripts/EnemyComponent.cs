using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public int maxHealth = 100; //Vida m�xima del enemigo.
    int currentHealth;  //Vida actual del enemigo.
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  //Al comienzo, el enemigo comienza con m�xima vida.
    }

    public void TakeDamage(int damage)  //M�todo para que el enemigo reciba da�o.
    {
        currentHealth = currentHealth - damage; //Cada hostia le va bajando la vida.

        //Animaci�n de recibir da�o.

        if (currentHealth <= 0) //Cuando la vida quede a 0 o menos, el enemigo muere.
        {
            Die();
        }
    }

    void Die()  //M�todo para que muera el enemigo.
    {
        Debug.Log("Samuerto");

        //Animaci�n de morir.

        //Quitar al enemigo.
    }
}
