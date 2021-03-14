using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Player player;
    BossHealth boss;

    public GameObject prefab;
    //players's health or boss' health
    public bool isPlayer = true;

    private Boss bossInfo;
    private GameObject bossBar = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bossInfo = GameObject.Find("BossTrigger").GetComponent<Boss>();

        if (!bossInfo.isDefeated())
            boss = GameObject.FindGameObjectWithTag("BossEntity").GetComponent<BossHealth>();

        for (int i = 0; i < player.health; ++i)
        {
            GameObject go = Instantiate(prefab, new Vector3(-128 + i * 62, 24 * isEven(i), 0), Quaternion.identity);
            go.transform.SetParent(transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //there are 6 child (5 gears for health and 1 back (black and yellow background))
        int index = transform.childCount - 1;

        if (isPlayer)
        {
            if (index > 0 && index > player.health)
                Destroy(transform.GetChild(index).gameObject);

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
            if (bossInfo.isDefeated())
                h = 0;
            else
                h = boss.health;

            if (index > 0 && index > h)
                Destroy(transform.GetChild(index).gameObject);

            for (int i = 0; i < h; ++i)
            {
                //avoid first child (black and yellow background)
                int ii = i + 1;
                transform.GetChild(ii).Rotate(0, 0, isEven(ii));
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

    public void instantiateHeal(int health)
    {
        int i = health - 1;

        GameObject go = Instantiate(prefab, new Vector3(-128 + i * 62, 24 * isEven(i), 0), Quaternion.identity);
        go.transform.SetParent(transform, false);
    }

    public void instantiateBossHealth(GameObject prefabBossHealth)
    {
        prefabBossHealth.GetComponentInChildren<RawImage>().color = Color.red;
        prefabBossHealth.GetComponentInChildren<HealthDisplay>().isPlayer = false;

        bossBar = Instantiate(prefabBossHealth, new Vector3(0, 400, 0), Quaternion.identity);
        bossBar.transform.SetParent(transform.parent, false);
    }

    public void destroyBossHealth()
    {
        Destroy(bossBar);
    }
}
