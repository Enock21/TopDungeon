using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void Start(){
        //Assim que o game inicia, uma caixa de colisão é criada.
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate(){
        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para a esquerda, para lugar nenhum ou para a direita.
        float x = Input.GetAxisRaw("Horizontal");

        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para baixo, para lugar nenhum ou para cima.
        float y = Input.GetAxisRaw("Vertical");

        //Mostra no console o valor de x a cada loop, ou seja, a cada passagem de frame.
        Debug.Log(x);

        //Mostra no console o valor de y a cada loop, ou seja, a cada passagem de frame.
        Debug.Log(y);

        /*
        moveDelta = Vector3.zero; //Vector3.zero cria um vetor de 3 posições totalmente zerado. Não se faz necessário aqui porque a linha abaixo faz o mesmo serviço.
        */

        //Reset moveDelta
        moveDelta = new Vector3(x,y,0);
        
        //Muda a direção do sprite dependendo se está indo para a esquerda ou para a direita.
        if (moveDelta.x > 0){
            transform.localScale = Vector3.one; //Isso é o mesmo que: "transform.localScale = new Vector3(1,1,1);". Cuidado para não colocar como Vector3(1,0,0), pois assim irá encolher o sprite horizontalmente, fazendo-o desaparecer do mapa.
        }else if (moveDelta.x < 0){
            transform.localScale = new Vector3(-1,1,1);
        }

        //Faz o sprite se mover.
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
