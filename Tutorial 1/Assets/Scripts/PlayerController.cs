using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    private int count;
    public UnityEngine.UI.Text scoreUI;
    public UnityEngine.UI.Text winUI;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        player.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Pickup"))
        {
            collider.gameObject.SetActive(false);
            count++;
            scoreUI.text = "SCORE: " + count.ToString();
        }

        if (count > 11)
        {
            winUI.text = "You win!\nGame created by: Xavier Virt";
        }
    }
}
