using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    public int coinCount;

    void Start()
    {
        UpdateScore();
    }
	
	void Update()
	{
		UpdateScore();
	}
    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        coinText.text = "Score: " + coinCount;
    }
}