using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint; //El punto que checkea si le ha dao a un enemigo.
    public LayerMask enemyLayers; //Para referirse a d�nde est�n los enemigos (para pegarles). WIP: Recuerda hacer la layer de los enemigos.

    public float attackRange = 0.5f; //El rango con el que ataca (radio).
    public int attackDamage = 40; //Da�o por golpe.

    // Update is called once per frame
    void Update()
    {
        //Atacar con la tecla Space
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            Attack();   
        }
    }

    void Attack()   //WIP: Falta hacer que al darle a la tecla de atacar, haga aleatoriamente (una u otra) las animaciones "Attack 1" y "Attack 2". Por el momento s�lo he puesto "Attack 1".
    {
        //Animaci�n de ataque.
        animator.SetTrigger("Attack");

        //Detectar a los enemigos en el rango de ataque (el radio del golpe).
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //"hitEnemies" es un array de los enemigos que hay.
                                                                                                               //"OverlapCircleAll" crea un c�rculo desde el objeto que le digas y del radio que le digas.
                                                                                                               //Funciona as�: OverlapCircleAll("centro","radio","lo que quieras detectar"). Funciona con f�sicas.


        //Da�o hacia los enemigos.
        foreach(Collider2D enemy in hitEnemies) //Para cada (foreach) enemigo (Collider2D enemy) en (in) el grupo de enemigos (hitEnemies).
        {
            enemy.GetComponent<EnemyComponent>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() //Esto dibuja una esfera que indica el radio del ataque. Estos dibuos se llaman "Gizmos".
    {
        if (attackPoint == null)    //Esto es por si el "attackPoint" no est� asignado (para que no haya errores en la consola).
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);   //Esto hace que se dibuje.
    }
}
