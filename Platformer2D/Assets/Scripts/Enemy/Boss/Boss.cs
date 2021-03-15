using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float        smooth = 5f;

    public GameObject   prefabHealthDisplay;

    private Light       mainLight;

    private GameObject  boss;
    private BossHealth  hp;

    private GameObject  panel;

    //when the player is in the trigger, face to the boss
    private bool    onFight = false;
    //when the boss is defeated
    private bool    defeated = false;
    private float   oldTime = 0;

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

        if (!onFight)
        {
            oldTime = Time.time;
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
            openDoor();
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

        oldTime = Time.time;
        onFight = true;

        if (hp.health > 0)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("BossEntity");
            boss.GetComponent<BossMove>().enabled = true;
        }

        panel.GetComponentInChildren<HealthDisplay>().instantiateBossHealth(ref prefabHealthDisplay);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        onFight = false;

        panel.GetComponentInChildren<HealthDisplay>().destroyBossHealth();
    }

    private void closeDoor()
    {
        GameObject door = GameObject.Find("BossEnter");
        Transform parent = door.transform.parent;

        Vector3 target = new Vector3(door.transform.position.x, parent.position.y - (parent.localScale.y / 2 + 5.7f), 0);

        door.transform.position = Vector3.Lerp(door.transform.position, target, Time.fixedDeltaTime * smooth * gameSpeed);
    }

    private void openDoor()
    {
        GameObject door = GameObject.Find("BossExit");
        Transform parent = door.transform.parent;

        Vector3 target = new Vector3(door.transform.position.x, parent.position.y - parent.localScale.y / 2, 0);

        door.transform.position = Vector3.Lerp(door.transform.position, target, Time.fixedDeltaTime * smooth * gameSpeed);
    }

    public bool isDefeated()
    {
        return defeated;
    }

    private void spawnObstacle()
    {

    }

    private void spawnEnemy()
    {

    }
}
