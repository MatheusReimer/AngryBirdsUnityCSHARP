using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour


{
    Vector3 _initialPosition;
    public bool _ballWasThrown;
    float _timeSittingAround;
    float _timeSinceThrow;
    public GameObject win;
    private WinConditionScript winScript;
    private void Awake(){
        //SAVING THE INITIAL POSITION OF THE BALL, THE BALL WILL MOVE TOWARDS THIS POSITION WHEN DRAGED IT
        _initialPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
           winScript = win.GetComponent<WinConditionScript>();
           
           
          
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1,_initialPosition);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);

        
       
        if(_ballWasThrown && GetComponent<Rigidbody2D>().velocity.magnitude <=0){
            _timeSittingAround += Time.deltaTime;
        }
        if(_ballWasThrown==true ){
            _timeSinceThrow += Time.deltaTime;
        }
        if(transform.position.y>15 || transform.position.x>15 ||  transform.position.x < -30 || _timeSittingAround>1||transform.position.y<-15){
            string activeScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(activeScene);
        }
      
     
        if(winScript.didWin==true){
            Debug.Log("WIN");
        }
        
      
        

    }
    void OnMouseDown(){
        SpriteRenderer color = GetComponent<SpriteRenderer>();
        color.color = Color.red;
      
        GetComponent<LineRenderer>().enabled = true;
    }
    void OnMouseUp(){
        //THIS VARIABLE STORES THE TOTAL AMOUNT OF DISTANT FROM THE STARTING POINT TO THE RELEASE POINT(X AND Y) 
        



        
        Vector2 directionToInitialPosition = _initialPosition -transform.position;
       
        const int FORCEMULTIPLIER = 450;
        SpriteRenderer color = GetComponent<SpriteRenderer>();
        color.color = Color.white;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * FORCEMULTIPLIER);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _ballWasThrown = true;
      
           GetComponent<LineRenderer>().enabled = false;
        
         
    }
    void OnMouseDrag(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x,newPosition.y);
    }
     private void OnCollisionEnter2D(Collision2D collision){
        if(_ballWasThrown==true && collision.collider.GetComponent<BackGroundScript>()!=null){
          
            Debug.Log("CU");
        }
    }

    

}
