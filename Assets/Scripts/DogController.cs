using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    [Header("Velocity")]
    public float dogVelocity;

    [Header("states")]
    private bool isDead = false;

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Collider2D col;
    // Use this for initialization
    void Start () {
        // pega os componentes do personagem
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();


        // ViewportToWorldPoint = settar posição inicial de acordo com a tela em que o jogo está sendo rodado
        Vector3 startPositionFlappy = Camera.main.ViewportToWorldPoint(new Vector3(0.2f,0.8f));
        // eixo Z para ficar alinhado com a câmera
        startPositionFlappy.z = 0;
        transform.position = startPositionFlappy;
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead) {
            Debug.Log("isdead");
            goDown();
            if (transform.position.y < -7)
            {
                Application.LoadLevel("Menu");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                goUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                goDown();
            }
        }

    }

    void goUp()
    {
        animator.SetTrigger("flappy");
        // adiciona força para o voo
        //rigidbody2D.AddForce(Vector2.up * flappyVelocity);
        rigidbody2D.velocity = (Vector2.up * dogVelocity);
    }

    void goDown()
    {
        animator.SetTrigger("flappy");
        // adiciona força para o voo
        //rigidbody2D.AddForce(Vector2.up * flappyVelocity);
        rigidbody2D.velocity = (Vector2.down * dogVelocity);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        Debug.Log(collision.collider.tag);
        // se for o pipe que colidiu, mata o Flappy Bird
        if (collision.gameObject.tag =="Pipe")
        {
            // Morreu
            isDead = true;
            //Deixa de colidir
            collision.collider.isTrigger = true;
            col.isTrigger = true;
        }
    }

    IEnumerator isDeadWait()
    {
        yield return new WaitForSeconds(1);
        
    }
}
