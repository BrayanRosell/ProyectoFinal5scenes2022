using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemigoController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float upSpeed = 70f;
    private bool limiteInicio = true;
    private bool limiteFin = false;
    private int contadorAvanza = 0;
    public int vidasEnemigo = 3;
    private playerController _playerController; 
    // Start is called before the first frame update
    void Start()
    {
          sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        rb2d = GetComponent<Rigidbody2D>(); 
        _playerController = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
         if(limiteInicio)
         {
             sr.flipX = true;
             rb2d.velocity = Vector2.up * upSpeed; 
         }
         if(contadorAvanza ==2 ){
            rb2d.velocity = new Vector2(-10,rb2d.velocity.y);
         }
         if(contadorAvanza ==3 ){
            rb2d.velocity = new Vector2(14,rb2d.velocity.y);
            contadorAvanza = 0;
         }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 9){
                limiteInicio = false;
                limiteFin = true;
                contadorAvanza++;
        }
        if(other.gameObject.layer == 10){
                 
                limiteFin = false;
                limiteInicio = true;
        }
        if(other.gameObject.layer == 7){
            _playerController.quitaVida();
            if(_playerController.vidas == 0){
                _playerController.muere();
                Destroy(other.gameObject,2);
                SceneManager.LoadScene  ("gameover");
                
            //Destroy(this.gameObject);
            }
            
        }
    }
    public void quitaVidaEnemy(){
        vidasEnemigo--;
    }
}
