using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionScript : MonoBehaviour
{

    public bool didWin;
    // Start is called before the first frame update
    void Start()
    {
        didWin=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.GetComponent<BallScript>()!=null){
            didWin=true;
            Destroy(gameObject);
            
        }
    }
}
