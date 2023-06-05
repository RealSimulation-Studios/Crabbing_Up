using UnityEngine;

public class standing_shooter : MonoBehaviour
{
    public GameObject AggroRange;

    public Transform player;
    
    public LayerMask whatIsGround, whatIsPlayer;



    //Attaking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float attackRange;
    public bool playerInAttackRange;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("Player").transform;

        int god = PlayerPrefs.GetInt("God");

        AggroRange.transform.localScale = new Vector3(attackRange*2, 0.2f, attackRange*2);


        if(god == 1)
        {
            AggroRange.SetActive(true);
        }
        else
        {
            AggroRange.SetActive(false);
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        //Check for sight and attack range


        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(playerInAttackRange) AttackPlayer();
    }





    private void AttackPlayer()
    {
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);
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
    }

}