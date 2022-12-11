using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    private Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 7f;
    public float meuLimite = 2.4f;


    public bool player1;

    //Mexendo com a IA
    public bool automatico = false;

    //Posicao da bola
    public Transform transformBola;

    // Start is called before the first frame update
    void Start()
    {
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        minhaPosicao.y = meuY;

        transform.position = minhaPosicao;
        float deltaVelocidade = velocidade * Time.deltaTime;

        //Se automatico for diferente de true
        if (!automatico) { 
            if (player1) { 
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    meuY = meuY + deltaVelocidade;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    meuY = meuY - deltaVelocidade;
                }
            }
            else
            {
                

            //Voltando para o automático
                if(Input.GetKey(KeyCode.Return)){
                    automatico = true;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    meuY = meuY + deltaVelocidade;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    meuY = meuY - deltaVelocidade;
                }
            }
           
        }
        else
        {


            //checando se o player 2 vai mexer:
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
                automatico = false;
            }

            //Raquete no Autom�tico
            //Acessando fun��o matem�tica
            //Velocidade do I.A
                meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.02f);

            
        }

        if (meuY < -meuLimite)
        {
            meuY = -meuLimite;
        }
        if (meuY > meuLimite)
        {
            meuY = meuLimite;
        }
    }
}
