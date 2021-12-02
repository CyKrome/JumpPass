using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Text PowerPointText;

    private int powerPointsCollected = 0;
    private Rigidbody rbComponent;
    private bool jump;
    private float xVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started!");
        rbComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = Input.GetAxis("Horizontal") * 3;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (gameObject.transform.position.y <= -10)
        {
            Destroy(gameObject);
            GameLost();
        }

        PowerPointText.text = powerPointsCollected.ToString();
    }

    private void FixedUpdate()
    {
        rbComponent.velocity = new Vector3(xVelocity, rbComponent.velocity.y, 0f);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            jump = false;
        }

        if (jump)
        {
            rbComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            powerPointsCollected++;
            PowerPointText.text = powerPointsCollected.ToString();
        }
    }

    [SerializeField] private void GameLost()
    {
        SceneManager.LoadScene("GameLost", LoadSceneMode.Single);
    }
}
