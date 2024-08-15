using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    
    public float playerSpeed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public TextMeshProUGUI goldText;

    private GoldMineController _goldMineController;

    private int _goldAmount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        goldText.text = $"GOLD: {_goldAmount}";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.position += playerSpeed * movement * Time.deltaTime;

        float movementFloat = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        
        animator.SetFloat("movement_speed", movementFloat);

        if (movementFloat > 0)
        {
            bool flipX = horizontal < 0;
            spriteRenderer.flipX = flipX;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_goldMineController == null) return;

            int digAmount = _goldMineController.DigGold();
            _goldAmount += digAmount;
            goldText.text = $"GOLD: {_goldAmount}";
        }

        Vector3 pos = transform.position;
        pos.z = -10;
        camera.transform.position = pos;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _goldMineController = other.GetComponent<GoldMineController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _goldMineController = null;
    }
}
