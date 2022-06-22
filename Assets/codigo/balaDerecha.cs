using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaDerecha : MonoBehaviour
{
     public float velocityX=20f;
    private Rigidbody2D rb2d;
    private enemigoController _enemyController; 
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
        _enemyController = FindObjectOfType<enemigoController>(); //lo busca
        //para eliminar gameobject
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
         rb2d.velocity = Vector2.right * velocityX;
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.layer == 6 ){
            Debug.Log("Entra");
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
            _enemyController.quitaVidaEnemy();
             if(_enemyController.vidasEnemigo == 0){
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
       if(other.gameObject.layer == 14 ){
             Destroy(this.gameObject);
              Destroy(other.gameObject);
        }
      
    }
}
