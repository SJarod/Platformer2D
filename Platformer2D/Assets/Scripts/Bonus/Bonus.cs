using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buffs
{
    BOOSTMAXLIFT,
    BOOSTJUMP,
    BOOSTSPEED,

    ENDMAXLIFT,
    ENDJUMP,
    ENDSPEED,

    HEAL,
    CHECKPOINT,
    END,
}

public class Bonus : MonoBehaviour
{
    public Buffs b = Buffs.BOOSTMAXLIFT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        Player player = other.GetComponent<Player>();
        Move move = other.GetComponent<Move>();

        switch (b)
        {
            case Buffs.BOOSTMAXLIFT:
                {
                    other.GetComponentInChildren<MoveLift>().maxLift = 10.0f;
                    break;
                }
            case Buffs.BOOSTJUMP:
                {
                    move.jumpForce = move.getBaseJumpForce() * 2;
                    break;
                }
            case Buffs.BOOSTSPEED:
                {
                    move.moveSpeed = move.getBaseMoveSpeed() * 2;
                    break;
                }
            case Buffs.ENDMAXLIFT:
                {
                    other.GetComponentInChildren<MoveLift>().maxLift = 2.5f;
                    break;
                }
            case Buffs.ENDJUMP:
                {
                    move.jumpForce = move.getBaseJumpForce();
                    break;
                }
            case Buffs.ENDSPEED:
                {
                    move.moveSpeed = move.getBaseMoveSpeed();
                    break;
                }
            case Buffs.CHECKPOINT:
                {
                    player.respawnPoint = transform.position;
                    break;
                }
            case Buffs.HEAL:
                {
                    if (other.gameObject.GetComponent<Player>().heal())
                        Destroy(this.gameObject);
                    break;
                }
            case Buffs.END:
                {
                    Menu menu = GameObject.Find("Canvas").GetComponent<Menu>();
                    menu.showYouWin();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
