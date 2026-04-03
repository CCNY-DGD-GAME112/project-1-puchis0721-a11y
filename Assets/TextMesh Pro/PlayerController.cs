using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;

    public float Speed = 5f;
    
    AudioSource audioSource;

    public CoinManager cm;

    private Vector2 movement;
    public float jumpPower;

    public bool isjumping;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        Vector2 vel = new Vector2(0, RB.linearVelocityY);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        
        if (Input.GetKeyDown(KeyCode.Z) && !isjumping)
        {
            vel.y = jumpPower; 
            isjumping = true;
        }
        
        if (transform.position.y < -20)
        {
            //Give me a game over
            SceneManager.LoadScene("Game Over");
        }
        
        RB.linearVelocity = vel;

    }
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            isjumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Hazard"))
		{
			SceneManager.LoadScene("Game Over");
		}
		
		if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
            audioSource.Play();
        }

    }
    
	private bool speedBoostActive = false;

    public IEnumerator SpeedBoost(float boostAmount, float duration)
    {
        if (speedBoostActive)
            yield break;

        speedBoostActive = true;

        float originalSpeed = Speed;
        Speed += boostAmount;

        
 

        yield return new WaitForSeconds(duration);

        Speed = originalSpeed;
        speedBoostActive = false;
    }
    // Input was being a pain in a butt, but I fixed it in the input settings!
}