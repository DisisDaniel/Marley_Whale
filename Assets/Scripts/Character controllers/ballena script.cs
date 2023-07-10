using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float nivelPiso = -3.72f;
    float limiteL   = -9.6f;
    float velocidad = 5f;
    float alturaSalto = 20f;
    bool canJump;
    float fuerzaDesplazamiento =5;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(-9.31f,nivelPiso,0);
        Debug.Log("INIT");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.rotation.z > 0.3 || gameObject. transform.rotation.z < -0.3){
            Debug.Log("ROTATION: " + gameObject.transform.rotation.z);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(Input.GetKey("right")){
            Debug.Log("right");      
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDesplazamiento,0));
        }
        else if(Input.GetKey("left") && gameObject.transform.position.x >= limiteL){
            gameObject.transform.Translate(-velocidad*Time.deltaTime, 0, 0);
        }
       ManageJump();
    }

    void ManageJump()
    {
        	
        if(Input.GetKey("up") && gameObject.transform.position.y < alturaSalto){
            gameObject.transform.Translate(0, velocidad*Time.deltaTime, 0);            
        }
        else{
        		canJump = false;
        		if(gameObject.transform.position.y > nivelPiso){
        			gameObject.transform.Translate(0, -velocidad*Time.deltaTime, 0);
        		}
        }

    }
}