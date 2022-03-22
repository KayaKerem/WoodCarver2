using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] Animator animPlayer;
    [SerializeField] Camera ortho;
    [SerializeField] WoodStack stack;
    public LayerMask mask;
    public Vector3 mouseDif;

    private Vector3 mousePos;
    private Vector3 firstPos;
    private bool rundStart;

    private void Start()
    {
        rundStart = settings.isPlaying;
        //myRB.centerOfMass = Vector3.zero; //Devrilmemesi için


    }
    public void MousePosRest()
    {
        firstPos = Vector3.zero;
        mousePos = Vector3.zero;
    }
    private void Update()
    {

        if (GameManager.levelFinish)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (settings.isPlaying)
        {
            if (!GameManager.levelFinish)
            {
                firstPos = Vector3.Lerp(firstPos, mousePos, 0.1f);

                if (Input.GetMouseButtonDown(0))
                    MouseDown(Input.mousePosition);
                else if (Input.GetMouseButton(0))
                    MouseHold(Input.mousePosition);
                else
                {
                    mouseDif = Vector3.zero;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && !rundStart)
        {
            rundStart = true;
            EventManager.Event_OnStartLevel();
        }

    }
    void FixedUpdate()
    {
        if (settings.isPlaying)
        {
            Move();
        }

    }

    void Move()
    {
        float xPos = Mathf.Clamp(transform.position.x + mouseDif.x, -5.5f, 5.5f);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z + settings.ForwardSpeed * Time.fixedDeltaTime);

    }

    private void MouseDown(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        firstPos = mousePos;
    }

    private void MouseHold(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        mouseDif = mousePos - firstPos;
        mouseDif *= settings.sensitivity * Time.deltaTime;
    }

    public void AnimControl(bool value, string valueName)
    {
        animPlayer.SetBool(valueName, value);
    }
    public void RunCharacterAnim(float woodCount, string valueName)
    {
        animPlayer.SetFloat(valueName, woodCount);
    }
    private void OnEnable()
    {
        EventManager.OnCharacterAnimControl += AnimControl;
        EventManager.OnCharacterRunAnim += RunCharacterAnim;
    }

    private void OnDisable()
    {
        EventManager.OnCharacterAnimControl -= AnimControl;
        EventManager.OnCharacterRunAnim -= RunCharacterAnim;
    }

}