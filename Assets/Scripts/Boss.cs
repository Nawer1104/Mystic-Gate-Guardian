using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{
    public static Boss Instance;

    public int maxHealth = 100;
    public int currentHealth;

    public Slider slider;

    public GameObject vfxDeath;

    public TextMeshProUGUI bossName;

    private int bossLevel = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);

        SetBossName();
    }

    private void SetBossName()
    {
        bossName.SetText("Demon King Level {0}" , bossLevel);
    }

    public void TakeDamage(int damge)
    {
        currentHealth -= damge;

        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameObject vfx = Instantiate(vfxDeath, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

/*            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);

            GameManager.Instance.CheckLevelUp();*/

            if (bossLevel < 2)
            {
                bossLevel += 1;

                maxHealth += 500;
                currentHealth = maxHealth;
                SetMaxHealth(maxHealth);
                SetBossName();
            }
            else
            {
                GameManager.Instance.ReSetGame();
            }
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
