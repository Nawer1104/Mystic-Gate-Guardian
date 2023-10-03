using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int soldierDamage = 1;

    public int updateDamagedCost = 100;

    public TextMeshProUGUI soldierDamgeText;

    public TextMeshProUGUI soldierDamgeUpdateText;

    public TextMeshProUGUI playerCoinText;

    public int coin = 0;

    public float spawnTime = 2f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ReSetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetText()
    {
        soldierDamgeText.SetText("Soldier damaged: {0}", soldierDamage);

        soldierDamgeUpdateText.SetText("Soldier update cost: {0}", updateDamagedCost);

        playerCoinText.SetText("Coin: {0}", coin);
    }

    private void Update()
    {
        SetText();
    }

    public void UpdateSoldier()
    {
        if (coin >= updateDamagedCost)
        {
            soldierDamage += 1;

            spawnTime -= 0.1f;

            coin -= updateDamagedCost;
        }
    }
}