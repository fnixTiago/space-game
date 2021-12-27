using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timerForNewPath;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }
    Vector3 getNewRandomPosition() {
        float x = Random.Range(-400, 400);
        float z = Random.Range(-400, 400);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
    IEnumerator DoSomething() {
        inCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log("invalido");
        while (!validPath) {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }
        inCoRoutine = false;
    }
    void GetNewPath() {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }
    // Update is called once per frame
    void Update()
    {
        if (!inCoRoutine) {
            StartCoroutine(DoSomething());
        }
    }
}
