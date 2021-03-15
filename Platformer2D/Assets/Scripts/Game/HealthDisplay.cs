using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Player      player;
    private BossHealth  boss;

    public GameObject   prefab;
    //players's health or boss' health
    public bool         isPlayer = true;

    private Boss        bossInfo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bossInfo = GameObject.Find("BossTrigger").GetComponent<Boss>();

        if (!bossInfo.isDefeated())
            boss = GameObject.FindGameObjectWithTag("BossEntity").GetComponent<BossHealth>();

        int h = 0;
        if (isPlayer)
            h = player.health;
        else if (!bossInfo.isDefeated())
            h = boss.health;

        if (h != 0)
        {
            for (int i = 0; i < h; ++i)
            {
                GameObject go = Instantiate(prefab, new Vector3(-128 + i * 62, 24 * isEven(i), 0), Quaternion.identity);
                go.transform.SetParent(transform, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //there are 6 child (5 gears for health and 1 back (black and yellow background))
        int gears = transform.childCount - 1;

        if (isPlayer)
        {
            if (gears > 0 && gears > player.health)
                Destroy(transform.GetChild(gears).gameObject);

            for (int i = 0; i < player.health; ++i)
            {
                //avoid first child (black and yellow background)
                int ii = i + 1;
                transform.GetChild(ii).Rotate(0, 0, isEven(ii));
            }
        }
        else
        {
            int h;
            if (!bossInfo.isDefeated())
                h = boss.health;
            else
                h = 0;

            if (gears > 0 && gears > h)
                Destroy(transform.GetChild(gears).gameObject);

            if (h != 0)
            {
                for (int i = 0; i < h; ++i)
                {
                    //avoid first child (black and yellow background)
                    int ii = i + 1;
                    transform.GetChild(ii).Rotate(0, 0, isEven(ii));
                }
            }
        }
    }

    private int isEven(int num)
    {
        int test = num / 2;
        if (test * 2 == num)
            return 1;   //even
        else
            return -1;  //odd
    }

    //instantiate a new gear (for the HUD)
    public void instantiateHeal(int health)
    {
        int i = health - 1;

        GameObject go = Instantiate(prefab, new Vector3(-128 + i * 62, 24 * isEven(i), 0), Quaternion.identity);
        go.transform.SetParent(transform, false);
    }
}
