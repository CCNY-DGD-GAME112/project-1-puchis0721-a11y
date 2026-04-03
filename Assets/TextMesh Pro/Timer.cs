using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class Timer : MonoBehaviour
{
   public TextMeshProUGUI timerText;
   public float timer = 5;
   public AudioSource audioSource;
   public AudioClip audioClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                
    }

	bool triggered = false;

    // Update is called once per frame
    void Update()
    {
		if (triggered) return;
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0)
        {
            triggered = true;
			StartCoroutine(PlaySoundThenLoad());
        }
	
    }

	IEnumerator PlaySoundThenLoad()
    {
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(audioClip.length);
        SceneManager.LoadScene("Game Over");
    }
}
