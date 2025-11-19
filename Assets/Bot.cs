using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    NavMeshAgent agente;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agente = this.GetComponent<NavMeshAgent>();
    }

    void Seek(Vector3 location)
    {
        agente.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        //Já que o Ladrão vai fugir, temos que calcular o Vetor inverso do Seek, que ia até o policial
        Vector3 fleeVector = location - this.transform.position;
        agente.SetDestination(this.transform.position - fleeVector);
    }

    // Update is called once per frame
    void Update()
    {
        //Seek(target.transform.position);
        Flee(target.transform.position);
    }
}
