using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_Enemy : MonoBehaviour{
    public int currentHealth;
    private Transform player;
    private Vector3 playerDistance;
    public int maxHealth = 5;
    public int touchingDamage;
    private Player playerCollision;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.currentHealth = maxHealth;
        this.touchingDamage = 35;
    }

    void Update(){
        isAlive();
        playerDistance = player.transform.position - transform.position;
    }

    private void isAlive(){
        if(currentHealth <= 0){
            //Adicionar animação de morte aqui
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage){ 
        currentHealth -= damage;
    }

    //causa dano no player e joga ele para trás
    private void OnCollisionEnter2D(Collision2D collision){
        playerCollision = collision.gameObject.GetComponent<Player>();
        if( playerCollision != null){
            //causa dano de encostar no player
            playerCollision.takeDamage(this.touchingDamage);

            //Joga o player para trás
            playerCollision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8 * (playerDistance.x / Mathf.Abs(playerDistance.x)),ForceMode2D.Impulse);
        }
    }

}
