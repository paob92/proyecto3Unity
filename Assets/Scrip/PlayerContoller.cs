using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//libreria para texto de linea 9

public class PlayerContoller : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(1, 1, 1);//valor en que voy a escalar al player cuando obtenga o recoga power
    public TMP_Text scoreText; //para asignar texto a unity 
    private int coins;//variable que es contador de las monedas

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumSound;
    public AudioClip crashSound;
    public AudioClip cointSound;//sonido de moneda
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();//trae componentes de lo que necesito 
        playerAnim = GetComponent<Animator>();//rtrae componentes de animator
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier; //Physisc bliblioteca de fisicas de unity 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //para dar uso a boton - !este signo niegua la exclamación siguiente pero solo para bool
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); //para ejercer fuerza y que salte el personaje
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumSound, 1.0f);
        }

        scoreText.text = coins.ToString();//se convierte entero en string, va sumando los puntos en UI
    }

    private void OnCollisionEnter(Collision collision)//collision es con el objeto con el que chocamos 
    {
        if (collision.gameObject.CompareTag("Ground")) //para activar el game over
        {
            isOnGround = true;

        } else if (collision.gameObject.CompareTag("Obtacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
         }
        if(collision.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("Coin");
            coins += 1; //aumenta la variable como un contador 
            //explosionParticle.Play();
            playerAudio.PlayOneShot(cointSound, 1.0f);
        }
        if(collision.gameObject.CompareTag("Power"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            transform.localScale = scaleChange; // le asignamos al que tiene este Scrit un nuevo vector3 el cual es => "scaleChange"
        }
    }

}
