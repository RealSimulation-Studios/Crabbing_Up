using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class simple_ai : MonoBehaviour
{
    public GameObject AggroRange;
    public GameObject Trigger;


    public NavMeshAgent agent;

    public Transform player;
    
    public LayerMask whatIsGround, whatIsPlayer;

    public int maxhealth;
    public int health;

    //Patroling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attaking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        int god = PlayerPrefs.GetInt("God");

        Trigger.transform.localScale = new Vector3(sightRange*2, 0.1f, sightRange*2);
        AggroRange.transform.localScale = new Vector3(attackRange*2, 0.2f, attackRange*2);


        if(god == 1)
        {
            Trigger.SetActive(true);
            AggroRange.SetActive(true);
        }
        else
        {
            Trigger.SetActive(false);
            AggroRange.SetActive(false);
        }

        health = maxhealth;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        //Check for sight and attack range

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;


    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX,transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {
        //no movement

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            GetComponent<AudioSource>().Play();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
 

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Füge hier den Code hinzu, der ausgeführt werden soll, wenn der Gegner stirbt (z. B. Punkte erhöhen, Animation abspielen, Gegner entfernen usw.)
        Destroy(gameObject);
    }
}
