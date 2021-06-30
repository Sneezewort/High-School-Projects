using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Movement : Agent
{
    public Transform cube;
    private int count;

    public override void OnEpisodeBegin()
    {
        Debug.Log("Begin");
        count = 1000;
        var rX = Random.Range(-4.0f, 4.0f);
        var rY = Random.Range(-4.0f, 4.0f);
        transform.localPosition = new Vector3(rX, 0, rY);
        //transform.localPosition = new Vector3(0, 0, 0);

        var randX = Random.Range(-4.0f, 4.0f);
        var randZ = Random.Range(-4.0f, 4.0f);
        while (Mathf.Abs(randX - transform.localPosition.x) < 0.5f)
            randX = Random.Range(-4.0f, 4.0f);
        while (Mathf.Abs(randZ - transform.localPosition.z) < 0.5f)
            randZ = Random.Range(-4.0f, 4.0f);
        cube.transform.localPosition = new Vector3(randX, 0, randZ);
        //cube.transform.localPosition = new Vector3(3, 0, 0);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Debug.Log("Action Received");
        if (count <= 0)
        {
            EndEpisode();
            SetReward(-1.0f);
        }
        if(transform.localPosition.x > 5f || transform.localPosition.x < -5f || transform.localPosition.z > 5f || transform.localPosition.z < -5f)
        {
            EndEpisode();
            SetReward(-1.0f);
        }
        count--;
        float moveX = vectorAction[0];
        float moveZ = vectorAction[1];
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * 4f;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        Debug.Log("Collected Observation");
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(cube.transform.localPosition);
    }

    /*public override void Heuristic(float[] actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[0] = Input.GetAxisRaw("Vertical");

    }*/
    public override void Heuristic(in ActionBuffers actionsOut)
    {
       ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
       continuousActions[0] = Input.GetAxisRaw("Horizontal");
       continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Food>(out Food food))
        {
            Debug.Log("Collision");
            SetReward(+1.0f);
            EndEpisode();
        }
    }
}
