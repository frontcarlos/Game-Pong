using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    public Rigidbody2D meuRB;

    private Vector2 minhaVelocidade;

    public float velocidade = 5f;

    //Limite do Gol
    public float limite = 10f;

    //Audio
    public AudioClip boing;
    public Transform transformCamera;

    // Start is called before the first frame update
    void Start()
    {
        int direcao = Random.Range(0, 4);

        if (direcao == 0)
        {
            minhaVelocidade.x = velocidade;
            minhaVelocidade.y = velocidade;
        }
        else if (direcao == 1)
        {
            minhaVelocidade.x = -velocidade;
            minhaVelocidade.y = velocidade;
        }
        else if (direcao == 2)
        {
            minhaVelocidade.x = velocidade;
            minhaVelocidade.y = -velocidade;
        }
        else
        {
            minhaVelocidade.x = -velocidade;
            minhaVelocidade.y = -velocidade;
        }
        meuRB.velocity = minhaVelocidade;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > limite || transform.position.x < -limite)
        {
            //Recarregar a cena
            SceneManager.LoadScene(0);
        }
    }

    //Colisões
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Som ao colidir
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
