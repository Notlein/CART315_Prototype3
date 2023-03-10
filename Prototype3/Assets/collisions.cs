using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisions : MonoBehaviour
{

    public bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        IsGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        


        if (collision.collider.CompareTag("Finish") || collision.collider.CompareTag("monster") && GetComponent<SpriteRenderer>().sortingLayerName == "Default")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.collider.CompareTag("monster"))
        {
            var list = GameObject.FindGameObjectsWithTag("monster");
            var list2 = GameObject.FindGameObjectsWithTag("platform");
            foreach (var e in list)
            {
                e.GetComponent<BoxCollider2D>().enabled = false;
            }
            foreach (var e in list2)
            {
                e.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    
}
