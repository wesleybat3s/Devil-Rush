using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float yatayHiz;
    [SerializeField] float yatayLimit;
    [SerializeField] float hareketHiz;
    [SerializeField] Rigidbody Devil;
    
    private float yatay;
    private Animator dAnimator;
    private Animator bAnimator;

    [SerializeField] float maxStamina = 100f;
    [SerializeField] float Stamina = 0f;
    [SerializeField] Slider StaminaSlider;

    private GameManager gm;


    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        Stamina = Stamina - 10 * Time.deltaTime;
        StaminaSlider.value = Stamina / maxStamina;

        if (Stamina <= 0)
        {
            dAnimator.SetTrigger("Dead");
            hareketHiz = 0f;
            yatayHiz = 0f;

            if (Input.GetMouseButtonDown(0))
            {
                gm.RestartGame();
            }
        }
    }

    private void FixedUpdate()
    {
        YatayMove();
        Ilerleme();
        dAnimator = GetComponent<Animator>();
        bAnimator = GetComponent<Animator>();
    }

    private void YatayMove()
    {
        float _newX;
        
        if (Input.GetMouseButton(0))
        {
            yatay = Input.GetAxisRaw("Mouse X");
        }
        _newX = transform.position.x + yatay * yatayHiz * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -yatayLimit, yatayLimit);

        Devil.transform.position = new Vector3(_newX, transform.position.y, transform.position.z);
    }

    private void Ilerleme()
    {
        Devil.transform.Translate(Vector3.forward * hareketHiz * Time.deltaTime);
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("engel"))
        {   
            dAnimator.SetTrigger("Dead");
            hareketHiz = 0f;
            yatayHiz=0f;
            Stamina = 0f;
  
        }

        if (other.CompareTag("Dur"))
        {
            hareketHiz = 0f;
            yatayHiz = 0f;
            yatay = 0f;  
            dAnimator.SetTrigger("Attack");
            
        }

        if (other.CompareTag("power"))
        {
            Stamina = Stamina + 15;
            
        }
        
    }
   
}
