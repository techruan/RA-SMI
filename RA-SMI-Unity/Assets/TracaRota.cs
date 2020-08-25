using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TracaRota : MonoBehaviour
{
	private LineRenderer tracaLinha;
    public NavMeshAgent agenteNavegacaoFlecha;
    private Vector3[] pontos;
    private NavMeshPath caminho;
    private Vector3 localCamera;
	public Transform goal;
    private bool tracandoRota;
    public Transform camera;
    public float linhaDistanciaDoChao;
    
    
    // Start is called before the first frame update
    void Start()
    {
        tracaLinha = GetComponent<LineRenderer>();
        caminho = new NavMeshPath();
        tracandoRota = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        // NavMeshPath caminho = new NavMeshPath();
        // 
        
        localCamera = camera.position;
        localCamera.y = linhaDistanciaDoChao;
        if(Input.GetMouseButtonUp(0)){
            tracandoRota = !tracandoRota;
            agenteNavegacaoFlecha.destination = goal.position;
        }
        if(tracandoRota){
            NavMesh.CalculatePath(localCamera, goal.position, NavMesh.AllAreas, caminho);
            AtualizaRota();
        }else{
            tracaLinha.positionCount = 0;
        }
    }

    private void AtualizaRota()
    {
        int i = 1;
        while(i < caminho.corners.Length){
            tracaLinha.positionCount = caminho.corners.Length;
            pontos = caminho.corners;
            for(int j = 0; j < pontos.Length; j++){
                pontos[j].y = linhaDistanciaDoChao;
                tracaLinha.SetPosition(j, pontos[j]);
            }

            i++;
        }
    }
}
