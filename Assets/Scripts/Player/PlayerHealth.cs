using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]private AudioSource dieSound;
    [SerializeField]private AudioSource hurtSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Trap")){
            dieSound.Play();
            Die();
        }
        else if(collision.gameObject.CompareTag("Enemy")){
            hurtSound.Play();
            TakeDamage(1);
            if(currentHealth <= 0){
                dieSound.Play();
                Die();
            }
        }
    }
    public void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetBool("hurt",true);
    }
    private void normalAnim(){
        anim.SetBool("hurt",false);
    }
}
