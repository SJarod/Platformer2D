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

    CHECKPOINT,
    END,
    HEAL,
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

        switch (b)
        {
            case Buffs.BOOSTMAXLIFT:
                {
                    other.GetComponentInChildren<MoveLift>().maxLift = 10.0f;
                    break;
                }
            case Buffs.BOOSTJUMP:
                {
                    other.GetComponent<Move>().jumpForce = 20;
                    break;
                }
            case Buffs.BOOSTSPEED:
                {
                    other.GetComponent<Move>().moveSpeed = 20;
                    break;
                }
            case Buffs.ENDMAXLIFT:
                {
                    other.GetComponentInChildren<MoveLift>().maxLift = 2.5f;
                    break;
                }
            case Buffs.ENDJUMP:
                {
                    Move move = other.GetComponent<Move>();
                    move.jumpForce = move.getBaseJumpForce();
                    break;
                }
            case Buffs.ENDSPEED:
                {
                    Move move = other.GetComponent<Move>();
                    move.moveSpeed = move.getBaseMoveSpeed();
                    break;
                }
            case Buffs.CHECKPOINT:
                {
                    break;
                }
            case Buffs.HEAL:
                {
                    if (other.gameObject.GetComponent<Player>().heal())
                        Destroy(this.gameObject);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
