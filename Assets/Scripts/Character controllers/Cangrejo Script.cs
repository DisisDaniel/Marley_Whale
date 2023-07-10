using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource salto_SFX;

    private int vidas = 3;
    bool canForce;
    float limiteL = -10.54f;
    float nivelPiso = -3.38f;
    float nivelTecho = -1.16f;
    float fuerzaSalto = 50;
    float fuerzaDesplazamiento =200;
    
    void Start()
    {
        gameObject.transform.position = new Vector3(-9.31f,nivelTecho,0);
        Debug.Log("INIT");
        Debug.Log("Vidas: " + vidas);
    }

    void Update()
    {
        if(gameObject.transform.rotation.z > 0.3 || gameObject.transform.rotation.z < -0.3){
            Debug.Log("ROTATION: " + gameObject.transform.rotation.z);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(Input.GetKey("right") && canForce){
            Debug.Log("right");      
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento,0));
        }
        else if(Input.GetKey("left") && gameObject.transform.position.x >= limiteL && canForce){
            Debug.Log("left");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuerzaDesplazamiento,0));
        }
        if(Input.GetKeyDown("up") && canForce){
            Debug.Log("UP - canForce: " + canForce);
            salto_SFX.Play();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSalto*Physics2D.gravity[1]*gameObject.GetComponent<Rigidbody2D>().mass));
            canForce = false;
        }
    }   
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Ground"){
            canForce = true;
            Debug.Log("GROUND COLLISION");
        }
        else if(collision.transform.tag == "Roca"){
            canForce = true;
            Debug.Log("Roca COLLISION");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Caida");   
        vidas -= 1;
        Debug.Log("Vidas: " + vidas);
        if(vidas <=0){
            Debug.Log("Game Over");
            vidas = 3;
        }
        gameObject.transform.position = new Vector3(-9.31f,nivelTecho,0);
    }
}
