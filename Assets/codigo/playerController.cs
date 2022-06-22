using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
     private float speed = 8;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreText;
    public Text scoreText2;
    public int vidas = 3;
    public GameObject rightBullet;
    public GameObject leftBullet;
    private enemigoController _enemigoController;
    private bool puedoSubir = false;
    public List<AudioClip> audioClips;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
        sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); 
        _enemigoController = FindObjectOfType<enemigoController>(); //lo busca
         audioSource.PlayOneShot(audioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(vidas == 5 ){
            scoreText.text = "IIIIIIIIIIIIIII";
        }
        if(vidas == 4 ){
             scoreText.text = "IIIIIIIIIIII";
        }
        if(vidas == 3 ){
            //scoreText.text = "vidas: "+vidas +"     " +"enemigos: " +enemigos;
            scoreText.text = "IIIIIIIII";
        }
         if(vidas == 2){
            scoreText.text = "IIIIII";
        }
        if(vidas == 1){
            scoreText.text = "III";
        }
        if(vidas ==0){
            scoreText.text = "";
        }
        if(_enemigoController.vidasEnemigo == 3 ){
            //scoreText.text = "vidas: "+vidas +"     " +"enemigos: " +enemigos;
            scoreText2.text = "OOOOOO";
        }
         if(_enemigoController.vidasEnemigo == 2){
            scoreText2.text = "OOOO";
        }
        if(_enemigoController.vidasEnemigo == 1){
            scoreText2.text = "OO";
        }
        if(_enemigoController.vidasEnemigo ==0){
            scoreText2.text = "";
        }
        
        if(vidas > 0){
            quieto();
            var position = new Vector2(transform.position.x+1.2f,transform.position.y+0.1f);
            if(puedoSubir == false){
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    sr.flipX = false;
                    correr();
                    rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
                    if(Input.GetKey(KeyCode.Space))
                    {
                    saltarF();
                    saltar();
                    }
                }
                else if(Input.GetKey(KeyCode.LeftArrow))
                {
                    sr.flipX = true;
                    correr();
                    rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
                    if(Input.GetKey(KeyCode.Space))
                    {
                    saltarF();
                    saltar();
                    }
                }else if(Input.GetKeyUp(KeyCode.Space))
                    {
                    saltarF();
                    saltar();
                     audioSource.PlayOneShot(audioClips[4]);
                    if(Input.GetKeyUp(KeyCode.A)){
                    disparar();
                    Instantiate(rightBullet,position,rightBullet.transform.rotation);
                     audioSource.PlayOneShot(audioClips[1]);
                     }
                    }
                else
                {
                    quieto();
                    rb2d.velocity = new Vector2(0,rb2d.velocity.y);
                }
                if(Input.GetKey(KeyCode.X)){
                     disparar();
                    if(Input.GetKeyUp(KeyCode.A))
                    {
                    
                        if(!sr.flipX)
                        {
                       
                            Instantiate(rightBullet,position,rightBullet.transform.rotation);
                            audioSource.PlayOneShot(audioClips[1]);
                        }
                        else{
                         position = new Vector2(transform.position.x-2f,transform.position.y-0.1f);
                            Instantiate(leftBullet,position,leftBullet.transform.rotation);
                            audioSource.PlayOneShot(audioClips[1]);
                        }
                        
                    }
                }

                //carga
                if(Input.GetKey(KeyCode.S))
                    {
                        carga();   
                    } 
            }//fin false
            //subir
            if(puedoSubir){
                 if(Input.GetKey(KeyCode.UpArrow)){
                subir();
                rb2d.velocity = new Vector2(rb2d.velocity.x,speed);
                }
            }  
        }else{
            muere();
             audioSource.PlayOneShot(audioClips[3]);
               
        }
    } void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 8){
             SceneManager.LoadScene  ("sceneTwo");
        }
         if(other.gameObject.layer == 13){
             SceneManager.LoadScene  ("sceneThree");
        }
        if(other.gameObject.layer == 11){//cargar
            Destroy(other.gameObject);
            carga(); 
            vidas++;   
            audioSource.PlayOneShot(audioClips[2]);      
        }
        if(other.gameObject.layer == 12){//subir
            puedoSubir = true;         
        }
        if(other.gameObject.layer == 14){//vidas --
             vidas--;  
             carga();  
              audioSource.PlayOneShot(audioClips[1]);
        }
         if(other.gameObject.layer == 15){
                 if(_enemigoController.vidasEnemigo == 0){
                    SceneManager.LoadScene  ("completo");
                 }
            
        }
    }
    public void saltarF(){

        var upSpeed = 20f;
        rb2d.velocity = Vector2.up * upSpeed;
       
    }
    
    public void quieto(){
       animator.SetInteger("Estado", 0);
    }
     public void correr(){
        animator.SetInteger("Estado", 1);        
    }
    public void saltar(){
        animator.SetInteger("Estado", 2);        
    }
    public void disparar(){
        animator.SetInteger("Estado", 3);        
    }
    public void subir(){
        animator.SetInteger("Estado", 4);        
    }
    public void carga(){
        animator.SetInteger("Estado", 5);        
    }
    public void muere(){
        animator.SetInteger("Estado", 6);        
    }
    public void quitaVida(){
       
        vidas--;
        Debug.Log(vidas);    
         audioSource.PlayOneShot(audioClips[1]);  
    }  
}
