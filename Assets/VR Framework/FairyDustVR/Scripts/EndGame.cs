using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EndGame : MonoBehaviour
{
    private ParticleSystem swirlPS;
    private Animator swirlAnim;
    private bool hasEnded;
    
    // Start is called before the first frame update
    void Start()
    {
        hasEnded = false;
        swirlPS = GetComponent<ParticleSystem>();
        swirlAnim = GetComponent<Animator>();

        swirlPS.isPlaying.Equals(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hasEnded = true;
        }
        
        switch (hasEnded)
        {
            //If hasEnded == true
            case true:
                //End the game and quit the app
                StartCoroutine(EndApp());
                break;
            case false:
                //The game is not over - so stop the coroutine
                StopAllCoroutines();
                break;
        }
    }

    private IEnumerator EndApp()
    {
        swirlAnim.SetBool("IsActive", true);
        yield return new WaitWhile(() => swirlPS.isPlaying);

        //End the experience 
        //SteamVR_Fade.View(Color.black, 1);
        print("Animation over");
    }
}
