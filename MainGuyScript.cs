using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGuyScript : MonoBehaviour
{
    public GameObject ballRolled;
    private BallScript ballScript;
    // Start is called before the first frame update
    void Start()
    {
        ballScript = ballRolled.GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
   {
       if(ballScript._ballWasThrown == true){
           GetComponent<Animator>().enabled = true;
       }
   }
    
}
