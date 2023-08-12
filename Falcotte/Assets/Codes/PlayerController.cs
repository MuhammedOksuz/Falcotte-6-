using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    UýController uýController;
    public Joystick joystick;
    public JoyButton joyButton;
    protected bool jump;
    [SerializeField] float jumpForce;
    public float speed;
    public float turnSpeed;
    public int coinCounter;
    public Text coinText;

    Animator animator;
    Sequence seq;


    private void Awake()
    {
        joyButton = FindObjectOfType<JoyButton>();
        joystick = FindObjectOfType<Joystick>();
        DOTween.Init();
        uýController = Object.FindObjectOfType<UýController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        Vector3 animation = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);
        rigidbody.velocity = animation;
        if (!jump && joyButton.printed)
        {
            jump = true;
            rigidbody.velocity += Vector3.up * jumpForce;
        }
        else if (jump && !joyButton.printed)
        {
            jump = false;
        }

        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", Mathf.Abs(rigidbody.velocity.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            DOTween.Init();
            seq = DOTween.Sequence();
            coinCounter++;
            //Destroy(other.gameObject);
            coinText.text = coinCounter.ToString();
            coinText.transform.DOScale(1.5f, 0.1f).OnComplete(() => coinText.transform.DOScale(1, 0.1f));
            ////other.gameObject.transform.DOMoveY(1, 0.1f);
            //seq.Append(other.transform.parent.DOMoveY(1, 1));
            //other.transform.parent.DOMoveY(1, 0.1f);
            other.gameObject.transform.DOScale(Vector3.zero, 0.1f).OnComplete(() => OnDestroy());
            void OnDestroy()
            {
                Destroy(other.gameObject);
            }
        }
    }



}
