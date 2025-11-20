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

    void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));
        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

        if ((toTarget > 90 && relativeHeading < 20) || target.GetComponent<Drive>().currentSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }
        
        float lookAhead = targetDir.magnitude / (agente.speed + target.GetComponent<Drive>().currentSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    // Update is called once per frame
    void Update()  //Estas 3 linhas de 
    {
        //Seek(target.transform.position);
        //Flee(target.transform.position);
        Pursue();
    }
}
