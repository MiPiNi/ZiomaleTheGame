using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    public SaveLoad saveLoad;

    public GameObject characterChoosePanel;
    public GameObject winPanel;
    public GameObject losePanel;

    public Rigidbody rb;
    public float speed = 25.0f;
    public float jumpForce = 400.0f;
    bool facingLeft;
    public bool canJump;
    public bool touchingRightEdge;
    public bool touchingLeftEdge;

    void Update()
    {
        if (!characterChoosePanel.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                if (!touchingRightEdge && !touchingLeftEdge)
                {
                    if (canJump)
                    {
                        rb.AddForce(new Vector2(0,jumpForce));
                    }
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!touchingLeftEdge)
                {
                    if (facingLeft)
                    {
                        transform.Rotate(Vector3.up, 180);
                        facingLeft = false;
                    }
                    rb.AddForce(Vector2.right * speed);
                }


            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!touchingRightEdge)
                {
                    if (!facingLeft)
                    {
                        transform.Rotate(Vector3.up, 180);
                        facingLeft = true;
                    }
                    rb.AddForce(Vector2.left * speed);
                }

            }
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("GAME");
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
            SceneManager.LoadScene("MENU");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            canJump = true;
        }
        else if(collision.collider.tag == "RightEdge")
        {
            touchingRightEdge = true;
        }
        else if (collision.collider.tag == "LeftEdge")
        {
            touchingLeftEdge = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            canJump = false;
        }
        else if (collision.collider.tag == "RightEdge")
        {
            touchingRightEdge = false;
        }
        else if (collision.collider.tag == "LeftEdge")
        {
            touchingLeftEdge = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WIN")
        {
            Debug.Log("win");
            Time.timeScale = 0f;
            if (Time.timeSinceLevelLoad <= VariableTag.BEST)
            {
                VariableTag.BEST = Time.timeSinceLevelLoad;
            }
            winPanel.SetActive(true);

            saveLoad.Save();
        }
        else if(other.tag == "LOSE")
        {
            Debug.Log("lose");
            Time.timeScale = 0f;
            losePanel.SetActive(true);
        }
        else if(other.tag == "DEATH")
        {
            Time.timeScale = 0f;
            losePanel.SetActive(true);
        }
    }


}
    
