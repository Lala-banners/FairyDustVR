using System.Collections;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    private ParticleSystem swirlPS;
    private Animator swirlAnim;
    public bool hasEnded;
    private AudioSource bgm;
    public float musicDuration;

    public static EndGameManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        hasEnded = false;
        swirlPS = GetComponent<ParticleSystem>();
        swirlAnim = GetComponent<Animator>();
        bgm = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (hasEnded)
        {
            //If hasEnded == true
            case true:
                //End the game and quit the app
                StartCoroutine(EndApp());
                break;
            case false:
                //The game is not over - so disable the PS
                swirlPS.Stop();
                break;
        }
    }

    private IEnumerator EndApp()
    {
        swirlAnim.SetBool("IsActive", true);
        swirlPS.Play();
        
        //Wait until the animation has stopped playing
        yield return new WaitForSecondsRealtime(swirlAnim.GetCurrentAnimatorStateInfo(0).length + swirlAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        
        swirlPS.Stop();
        
        StartCoroutine(StartFade(bgm, musicDuration, 0f));
        
        yield return new WaitForSeconds(musicDuration + FadeScreen.instance.duration);
        
        FadeScreen.instance.Fade();
        
        QuitGame();
    }
    
    private IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
