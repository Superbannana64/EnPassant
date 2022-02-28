using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class BasicPlayer : MonoBehaviour
{

    //[SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float maxCharacterNum = 4, TimeToSwitch;
    [SerializeField] private int characterWeight;
    [SerializeField] private Sprite inactiveSprite, activeSprite;
    [SerializeField] private PolygonCollider2D polyCollider2D;
    private SpriteRenderer mySpriteRenderer;
    public float startingCharacterNum;
    public float xSpeed = 10f, jumpForce = 300f;
    private bool isGrounded = false, movementOn = false;
    float characterNum = 1, internalTime=0;
    void Start()
    {
        //player = GameObject.Find("playerCharacter");
        internalTime = 0;
        rb2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        polyCollider2D = GetComponent<PolygonCollider2D>();

        PlayerSwitchController();
        gameObject.GetComponent<PlayerRespawn>().NewPosition();
    }

    void Update()
    {
        CheckGround();
        float input = playerMovementInput();
        InternalTimer();
        switchCharacter();
        playerMovement(input);
        playerJumpInput();
    }

    float playerMovementInput() //Checks player's input
    {
        float xMove = Input.GetAxis("Horizontal")*xSpeed;
        //Jump and switch player inputs can be added here
        return xMove;
    }

    void playerMovement(float input) //Chcks and moves player based on xMove
    {
        if(movementOn)
        {
            rb2d.velocity = new Vector2(input, rb2d.velocity.y);    
        }
        else
        {
            //Debug.Log("Not moving");
        }
    }

    void CheckGround()
    {
        Collider2D col = Physics2D.OverlapCircle(groundCheck.position, 1f, ground);
        if(col == null)
        {
            //Debug.Log("Ungrounded");
            isGrounded = false;
        }
        else
        {
            //Debug.Log("Grounded");
            isGrounded = true;
        }
        
    }
    void playerJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && movementOn)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    bool inputToSwitch()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.O))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void InternalTimer()
    {
        internalTime += Time.deltaTime;
        Debug.Log(Mathf.FloorToInt(internalTime));
    }
    bool InternalTimerSwitch()
    {
        if(Mathf.FloorToInt(internalTime) == TimeToSwitch)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void switchCharacter()
    {
        if(inputToSwitch()||InternalTimerSwitch())
        {
            internalTime = 0;
            characterNum++;
            if(characterNum > maxCharacterNum)
            {
                characterNum = 1;
            }
            Debug.Log("Character Number Check");
            Debug.Log(characterNum);
            PlayerSwitchController();
        }
    }
    void playerAnimation() //Will be used when player obtains animation
    {

    }

    void PlayerSwitchController()
    {
        if(characterNum == startingCharacterNum)
        {
            movementOn = true;
            rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            gameObject.layer = 1;
            mySpriteRenderer.sprite=activeSprite;
            polyCollider2D.TryUpdateShapeToSprite();
        }
        else if(characterNum != startingCharacterNum)
        {
            movementOn = false;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.layer = 6;
            mySpriteRenderer.sprite = inactiveSprite;
            polyCollider2D.TryUpdateShapeToSprite();
        }
    }
    public int GetWeight()
    {
        return characterWeight;
    }

    void OnStickyFloor(float speedChange)
    {
        xSpeed -= speedChange;
        jumpForce = jumpForce/2;
        Debug.Log("SlowDown");
    }
    void OffStickyFloor(float speedChange)
    {
        xSpeed += speedChange;
        jumpForce = jumpForce * 2;
        Debug.Log("SpeedUp");
    }
    void OnSlipperyFloor(float speedChange)
    {
        xSpeed += speedChange;

        Debug.Log("SpeedUp");
    }
    void OffSlipperyFloor(float speedChange)
    {
        xSpeed -= speedChange;
        Debug.Log("SlowDown");
    }
}
