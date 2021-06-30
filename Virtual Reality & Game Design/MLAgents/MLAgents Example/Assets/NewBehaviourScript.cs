using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class NewBehaviourScript : Agent
{
    public Transform cube;
    private int count;
    public override void OnEpisodeBegin()
    {
        count = 1200;
        transform.localPosition = new Vector3(0, 0, 0);
        cube.transform.localPosition = new Vector3(2, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        SetReward(1f);
        EndEpisode();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(cube.transform.localPosition);
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        transform.Translate(new Vector3(vectorAction[0] * Time.deltaTime, 0, vectorAction[1] * Time.deltaTime) * 3);
        count--;
        if (count <= 0)
            EndEpisode();
    }
}
