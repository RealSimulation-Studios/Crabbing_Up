using UnityEngine;
using UnityEngine.SceneManagement;

public class crs_movement : MonoBehaviour
{   
    public Transform player;
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public GameObject projectile;
    public GameObject MobGroup1;
    public int Health = 40;
    public int healCooldown;
    public int SWCooldowntime;
    public GameObject SW;

    private bool canAttack = true;
    private bool canHeal = true;
    public bool canSW = true;

    private int cwave;

    private void Update()
    {      

        cwave = this.GetComponent<Wave>().currWave;

        if(isGrounded)
        {
            if(cwave == 0)
            {
                this.GetComponent<Wave>().currWave = 1;
            }
        }
        
        if(cwave == 1)
        {
            transform.LookAt(player.position);
            move_tPLayer();
            
        }

        if(cwave == 2)
        {
            transform.LookAt(player.position);
            flee_fPlayer();
            MobGroup1.SetActive(true);
            Heal();
        }

        if(cwave == 3)
        {   
            transform.LookAt(player.position);
            move_tPLayer();
            MobGroup1.SetActive(false);
        }

        if(cwave == 1 && Health < 12)
        {
            this.GetComponent<Wave>().currWave = 2;
        }

        if(cwave == 2 && Health == 40)
        {
            this.GetComponent<Wave>().currWave = 3;
        }

        if(cwave == 3 && Health <= 0)
        {
            SceneManager.LoadScene(3);
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && canAttack)
        {   
            if(cwave == 1)
            {
                ShootPlayer();
            }

            if(cwave == 3)
            {
                ShootPlayer();
            }
        }
    }

    private void move_tPLayer()
    {   
        
        
            Vector3 direction = (player.position + transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        
    }

    private void flee_fPlayer()
    {
        Vector3 direction = (player.position + transform.position).normalized;
        transform.Translate(-direction * moveSpeed * Time.deltaTime);
    }

    private void ShootPlayer()
    {
        // Wähle einen zufälligen Angriff aus
        int attackIndex = 1;

        switch (attackIndex)
        {
            case 0:
                MeleeAttack();
                break;
            case 1:
                RangedAttack();
                break;
        }

        // Starte den Angriffscooldown
        StartCoroutine(AttackCooldown());
    }

    private void Heal()
    {
        if(canHeal == true)
        {
            Health += 1;
            canHeal = false;
            StartCoroutine(HealCooldown());
        }
    }

    private void MeleeAttack()
    {
        // Implementiere hier den Nahkampf-Angriff
        Debug.Log("Nahkampf-Angriff!");

        // Füge hier den Code hinzu, um dem Spieler Schaden zuzufügen oder andere Aktionen auszuführen
    }

    private void RangedAttack()
    {   
        Debug.Log("Fernkampf-Angriff!");
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
        rb.AddForce(transform.up * 2f, ForceMode.Impulse);
        

        // Füge hier den Code hinzu, um dem Spieler Schaden zuzufügen oder andere Aktionen auszuführen
    }



    private System.Collections.IEnumerator AttackCooldown()
    {
        canAttack = false;

        // Warte für die Dauer des Angriffscooldowns
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    

    private System.Collections.IEnumerator HealCooldown()
    {
        canHeal = false;

        // Warte für die Dauer des Angriffscooldowns
        yield return new WaitForSeconds(healCooldown);

        canHeal = true;
    }


    public void TakeDamage(int damage)
    {   
        if(cwave != 2)
        {   
            
            
            Health -= damage;
            
        }
        
    }


    public bool isGrounded;

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}