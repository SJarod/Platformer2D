using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float        smooth = 5f;
    public GameObject   prefabHealthDisplay;

    private Light       mainLight;

    private GameObject  boss;
    private BossHealth  hp;

    private GameObject  panel;
    private GameObject  bossBar = null;

    //when the player is in the trigger, face to the boss
    private bool    onFight = false;
    //when the boss is defeated
    private bool    defeated = false;

    private float   gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainLight = FindObjectOfType<Light>();

        boss = GameObject.FindGameObjectWithTag("BossEntity");
        hp = boss.GetComponent<BossHealth>();

        panel = GameObject.FindGameObjectWithTag("Display");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameSpeed = GameObject.Find("Canvas").GetComponent<Menu>().gameSpeed;

        float dt = Time.fixedDeltaTime * smooth;

        //change light to see the boss better
        if (!onFight)
        {
            mainLight.transform.rotation = Quaternion.Lerp(mainLight.transform.rotation, Quaternion.Euler(60, 0, 0), dt);
            mainLight.intensity = Mathf.Lerp(mainLight.intensity, 1f, dt);
        }
        else
        {
            closeDoor();
            mainLight.transform.rotation = Quaternion.Lerp(mainLight.transform.rotation, Quaternion.Euler(12, 0, 0), dt);
            mainLight.intensity = Mathf.Lerp(mainLight.intensity, 0.5f, dt);
        }

        if (hp.health <= 0)
        {
            defeated = true;
            Destroy(boss);
            openDoor("BossEnter");
            openDoor("BossExit");
        }
    }

    public bool isOnFight()
    {
        return onFight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        onFight = true;

        if (hp.health > 0)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("BossEntity");
            boss.GetComponent<BossMove>().enabled = true;
        }

        instantiateBossHealth(ref prefabHealthDisplay);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        onFight = false;

        destroyBossHealth();
    }

    //instantiate a new health bar (for the boss)
    public void instantiateBossHealth(ref GameObject prefabBossHealth)
    {
        prefabBossHealth.GetComponentInChildren<RawImage>().color = Color.red;
        prefabBossHealth.GetComponentInChildren<HealthDisplay>().isPlayer = false;

        bossBar = Instantiate(prefabBossHealth, new Vector3(0, 400, 0), Quaternion.identity);
        bossBar.transform.SetParent(panel.transform, false);
    }
    public void destroyBossHealth()
    {
        Destroy(bossBar);
    }

    private void closeDoor()
    {
        GameObject door = GameObject.Find("BossEnter");
        Transform parent = door.transform.parent;

        //values for closing door found by hardcoding
        Vector3 target = new Vector3(door.transform.position.x, parent.position.y - (parent.localScale.y / 2 + 5.7f), 0);

        door.transform.position = Vector3.Lerp(door.transform.position, target, Time.fixedDeltaTime * smooth * gameSpeed);
    }

    private void openDoor(string doorName)
    {
        GameObject door = GameObject.Find(doorName);
        Transform parent = door.transform.parent;

        //values for opening door found by hardcoding
        Vector3 target = new Vector3(door.transform.position.x, parent.position.y - parent.localScale.y / 2, 0);

        door.transform.position = Vector3.Lerp(door.transform.position, target, Time.fixedDeltaTime * smooth * gameSpeed);
    }

    public bool isDefeated()
    {
        return defeated;
    }

    private void spawnObstacle()
    {
        //TODO
    }

    private void spawnEnemy()
    {
        //TODO
    }
}
