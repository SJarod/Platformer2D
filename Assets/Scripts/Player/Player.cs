using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int      health = 5;
    private int     maxHealth;

    public float    dmgCoolDown = 1f;
    private float   dmgTime = 0f;

    public Vector3  respawnPoint = new Vector3(0, 3, 0);

    Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;

        menu = GameObject.Find("Canvas").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if (Time.time - dmgTime < dmgCoolDown)
            return;

        dmgTime = Time.time;

        if (--health <= 0)
        {
            menu.showYouLose();
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
