using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotor : MonoBehaviour
{
    public Transform lookAt; //Indica a direção do player a ser focado
    public float boundX = 0.15f; //Indica até onde o player pode se mover no eixo x antes de a câmera começar a segui-lo
    public float boundY = 0.05f; //Indica até onde o player pode se mover no eixo y antes de a câmera começar a segui-lo

    //LateUpdate é atualizado após o Update e FixedUpdate. Para câmera o LateUpdate é recomendado para que não haja um delay visual no jogo
    private void LateUpdate()
    {
        //Diferença entre este frame e o próximo frame
        Vector3 delta = Vector3.zero;

        //TESTANDO SE O PLAYER SE MOVE ALÉM DOS LIMITES DO EIXO X:
        
        //Diferença entre as distancias atuais no eixo x do lookAt, isto é, do player, e a deste objeto (CameraMotor)
        float deltaX = lookAt.position.x - transform.position.x;
        //Condição em que o player se move além dos limites para a direita
        if (deltaX > boundX){
            deltaX = deltaX + boundX;
        }
        //Condição em que o player se move além dos limites para a esquerda
        if (deltaX < -boundX){
            deltaX = deltaX - boundX;
        }

        //TESTANDO SE O PLAYER SE MOVE ALÉM DOS LIMITES DO EIXO Y:

        //Diferença entre as distancias atuais no eixo y do lookAt, isto é, do player, e a deste objeto (CameraMotor)
        float deltaY = lookAt.position.y - transform.position.y;
        //Condição em que o player se move além dos limites para cima
        if (deltaY > boundY){ 
            deltaY = deltaY + boundY;
        }
        //Condição em que o player se move além dos limites para baixo
        if (deltaY < -boundY){
            deltaY = deltaY - boundY;
        }

        transform.position += new Vector3(deltaX, deltaY, 0);

    }
}