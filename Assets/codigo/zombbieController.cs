using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zombbieController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float speed = 12;
    private playerController _playerController; 
    private bool limiteInicio = true;
    private bool limiteFin = false;
     
        // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>(); 
         _playerController = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(limiteInicio){
             sr.flipX = true;
              rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
           
        }
        if(limiteFin){
            sr.flipX = false;
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        } 
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 9){
                limiteInicio = false;
                limiteFin = true;
        }
        if(other.gameObject.layer == 10){
                 
                limiteFin = false;
                limiteInicio = true;
        }
         if(other.gameObject.layer == 7){
            _playerController.quitaVida();

             _playerController.carga();
            if(_playerController.vidas == 0){
                _playerController.muere();
                Destroy(other.gameObject,2);
                 SceneManager.LoadScene  ("gameover");
            //Destroy(this.gameObject);
            }
            
        }
    }
}
