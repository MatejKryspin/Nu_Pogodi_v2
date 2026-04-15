using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public BoxCollider2D hitBox;
    public Rigidbody2D myRigidbody;
    public JumpHitbox jump;
    public GrabZone grab;
    public Coroutine speedcoroutine;
    public Coroutine reversedcoroutine;
    public Image sprintBar;


    public float jumpStrength = 2;
    public float moveSpeed = 4f; //normal speed without any effects
    public float sprintSpeed; //speed when you are sprinting
    public float baseSpeed; //normal speed without any effects
    public float timer = 0; //how long you have been sprinting
    public float interval = 2; //how fast the sprint timer goes up and down
    public float relax = 0; //when you are sprinting you are not relaxed but when you stop sprinting you start relaxing and when you are relaxed your sprint starts refilling
    public float maxSprint = 4; //when you reach max sprint you are exhausted and you need to wait some time to be able to sprint again, also when you are exhausted your speed is reduced by 2
    public bool exhausted; //when you are exhausted you cant sprint and your speed is reduced by 2 you need to wait some time to be able to sprint again
    public bool pressed;
    public bool reversed;
    public bool speeding;
    public float restartSpeed;

    public float fadeLimit = 1.5f;
    public float fading = 0;
    public bool sprinted = false;
    public float sprintBarWidth;
    public bool fullSprintBar;

    public Vector3 spawnPosition;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPosition = transform.position;
        baseSpeed = moveSpeed;
        restartSpeed = baseSpeed;
        sprintSpeed = moveSpeed + 3f;
        sprintBar.enabled = false;
        fullSprintBar = true;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal"); //changes player model looking in direction where user is moving

        if (move > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.x), 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.x), 1);
        }

        //input system
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (reversed)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            if (reversed)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
        }

        //pressed: resets relax, relax is when you are exhausted when its resets, timer is for how long you can sprint
        if (Input.GetKey(KeyCode.LeftShift) == true && exhausted == false && speeding == false)
        {
            pressed = true;
            moveSpeed = sprintSpeed;
            relax = 0;
            timer += 1 * Time.deltaTime * interval;

            if (timer > maxSprint)
            {
                exhausted = true;
            }
        }
        else if (exhausted == false)
        {
           
            moveSpeed = baseSpeed; 
            
            
        }
        else if (exhausted == true) //not sprinting but you are exhausted you need to wait some time to sprint again
        {
            relax = 0;
            moveSpeed = baseSpeed - 2f;
            timer -= 2 * Time.deltaTime;
            if (timer <= 0)
            {
                exhausted = false;
                timer = 0;
            }

        }

        //when you sprinted you start relaxing and when you are relaxed your sprint starts refuling
        if (Input.GetKey(KeyCode.LeftShift) == false && exhausted == false && pressed == true) 
        {
            
            relax += 1 * Time.deltaTime;
            if (relax >= 1.5)
            {
                timer -= 2 * Time.deltaTime;
            }
            if (timer < 0)
            {
                pressed = false;
                timer = 0;
                relax = 0;
            }
        }

        //jump but only when you are standing on the ground
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (jump.Grounded() == true)
            {
                myRigidbody.linearVelocity = Vector2.up * jumpStrength;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) == true) 
        {
            fullSprintBar = false;
            fading = 0;
            sprintBar.enabled = true;
            sprinted = true;

        }
        if (Input.GetKey(KeyCode.LeftShift) == false && sprinted == true && fullSprintBar == true)
        {
            fading += Time.deltaTime;
            if (fading >= fadeLimit) {
                sprintBar.enabled = false;
                sprinted = false;
            }
        }
        if (timer > 0)
        {
            sprintBar.fillAmount = 1f - (timer * (1f / maxSprint));
        }
        else
        {
            sprintBar.fillAmount = 0f;
        }

    }


    public void TeleportToSpawn()
    {
        transform.position = spawnPosition;
    }

    public void StartSpeedEffect(float boostAmount, float duration)
    {
        if (speedcoroutine != null)
        {
            StopCoroutine(speedcoroutine);
            baseSpeed = restartSpeed;
            speeding = false;
            speedcoroutine = null;
        }
        speedcoroutine = StartCoroutine(SpeedBoostRoutine(boostAmount, duration));
    }

    public void StartReversedEffect(float duration)
    {
        if (reversedcoroutine != null)
        {
            StopCoroutine(reversedcoroutine);
            reversed = false;
            reversedcoroutine = null;
        }
        reversedcoroutine = StartCoroutine(ReversedControlRoutine(duration));
    }

    IEnumerator SpeedBoostRoutine(float boostAmount, float duration)
    {
        baseSpeed += boostAmount;
        speeding = true;
        yield return new WaitForSeconds(duration);
        baseSpeed -= boostAmount;
        speeding = false;
        speedcoroutine = null;
    }

    IEnumerator ReversedControlRoutine(float duration)
    {
        reversed = true;
        yield return new WaitForSeconds(duration);
        reversed = false;
        reversedcoroutine = null;
    }
}


/////// prosim priste az tady budes  prosim prosim prosim prosiiiiiiiiiim  
/// udelej ten timer jak dlouho trva ten effekt plsky
/// taky udelej sprite pro ten sellpoint
/// udelej sprite pro random vajce 
/// pridej nejaky novy a pridej dalsi levely
/// 
/// 
/// pak jeste potrebuju shop ale to je asi na pozdeji :sob:
