using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 5;
    private int maxHealth;

    private float dmgTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if (Time.time - dmgTime < 1f)
            return;

        dmgTime = Time.time;

        if (--health <= 0)
        {
            SceneManager.LoadScene("Platformer2D");
        }
    }

    public bool heal()
    {
        if (health >= maxHealth)
            return false;

        HealthDisplay hd = GameObject.Find("Health Panel").GetComponent<HealthDisplay>();
        hd.instantiateHeal(++health);

        return true;
    }
}
