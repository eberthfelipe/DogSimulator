using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour {

    [Header("References")]
    public ScrollPipe pipePreFab;

    [Header("Pipes")]
    public int maxPipes;
    public float pipesOffset;

    private Transform[] pipes;
    private int firstPipeIndex;

    // Use this for initialization
    void Start () {
        pipes = new Transform[maxPipes];
        Vector3 pipePosition;

        for(int i=0; i<maxPipes; i++)
        {
            // encontra posição de cada pipe
            pipePosition = Camera.main.ViewportToWorldPoint(new Vector3((1f + pipesOffset * i), Random.Range(-0.2f,0.2f), 0f));

            pipePosition.z = 0f;

            //Criar cada pipe a partir do prefab
            pipes[i] = Instantiate(pipePreFab.transform) as Transform;
            // set the parent
            pipes[i].parent = transform;
            // set the position in the screen
            pipes[i].localPosition = pipePosition;
        }

        firstPipeIndex = 0;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = Camera.main.ViewportToWorldPoint(pipes[firstPipeIndex].position);

        if(screenPos.x < -200f)
        {
            // Index da posição anterior
            int lastPipeIndex = (pipes.Length + firstPipeIndex - 1) % pipes.Length;
            float worldOffset = (
                Camera.main.ViewportToWorldPoint(
                    new Vector3(pipesOffset, 0f, 0f)
                ) -
                (Camera.main.ViewportToWorldPoint(
                    new Vector3(0f, 0f, 0f)
                    ))
                ).x;

            // Posiciona atrás do último Pipe
            pipes[firstPipeIndex].localPosition = pipes[lastPipeIndex].localPosition + new Vector3(worldOffset, 0f, 0f);

            // Define uma nova posição para o eixo Y, aleatoriamente
            Vector3 pipePos = pipes[firstPipeIndex].localPosition;
            //Random.Range(-0.2f,0.2f)
            pipePos.y = Camera.main.ViewportToWorldPoint(
                    new Vector3(0f, Random.Range(-0.2f, 0.2f), 0f)
                    ).y;
            pipes[firstPipeIndex].localPosition = pipePos;
            // Atualiza o primeiro elemento do array circular
            firstPipeIndex = (firstPipeIndex + 1) % pipes.Length;
        }

	}
}
