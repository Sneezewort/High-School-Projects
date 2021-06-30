using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;

public class MovementScript : Agent
{
    int count = 3000;
    public enum Team
    {
        Red = 0,
        Blue = 1
    }
    int dir;
    //bool ground;
    public Team team;
    Rigidbody rb;
    public GameObject soccerBall;
    public GameObject enemy;
    public GameObject leg;
    Quaternion originalRotation;
    Quaternion targetRotation;
    float rotateTimer = 1.5f;
    float secondTimer = 1f;
    bool isKick = false;

    public override void OnEpisodeBegin()
    {
        //Debug.Log("Begin");
        count = 1000;
        if (team == Team.Red)
        {
            dir = 1;
            transform.position = new Vector3(-10f, 1.5f, 0f);
            enemy.transform.position = new Vector3(10f, 1.5f, 0f);
        }
        else if(team == Team.Blue)
        {
            dir = -1;
            transform.position = new Vector3(10f, 1.5f, 0f);
            enemy.transform.position = new Vector3(-10f, 1.5f, 0f);
        }
        originalRotation = leg.transform.rotation;
        targetRotation = leg.transform.rotation;
        soccerBall.transform.position = new Vector3(0f, 5f, 0f);
        soccerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        soccerBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        leg.gameObject.GetComponent<MeshRenderer>().enabled = false;
        leg.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        isKick = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == soccerBall)
            SetReward(1f);
    }
  
    public void jump()
    {
        if (transform.position.y < 1.6)
        {
            rb.AddForce(new Vector3(0f, 60f, 0f), ForceMode.Impulse);
        }
        else
        {

        }
    }
    public void kick()
    {
        if (isKick == false)
        {
            targetRotation = Quaternion.AngleAxis(120 * dir, Vector3.forward);
            leg.gameObject.GetComponent<MeshRenderer>().enabled = true;
            leg.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            isKick = true;
        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log("" + count);
        if(count <= 0)
        {
            EndEpisode();
           //SetReward(-1f);
        }
        count--;
        var direction = new Vector3(3f, 0f, 0f);
        var options = actions.DiscreteActions[0];
        var jumpOptions = actions.DiscreteActions[1];
        var kickOptions = actions.DiscreteActions[2];
        //Debug.Log("" + actions.DiscreteActions[0].ToString());
        switch (options)
        {
            case 1:
                rb.AddForce(direction * dir * 2f, ForceMode.Impulse);
                break;
            case 2:
                rb.AddForce(direction * dir * -2f, ForceMode.Impulse);
                break;
        }
        if (jumpOptions == 1)
            jump();
        if (kickOptions == 1)
            kick();
        Debug.Log("Jump: " + jumpOptions);
        Debug.Log("Kick: " + kickOptions);
        
        //Debug.Log("" + options.ToString());
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var movement = actionsOut.DiscreteActions;
        movement.Clear();
        //forward
        if (Input.GetKey(KeyCode.A))
        {
            movement[0] = 1;
            //Debug.Log("A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement[0] = 2;
        }
        //rotate
        if (Input.GetKey(KeyCode.W))
        {
            movement[1] = 1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movement[2] = 1;
        }
    }


    /*public override void CollectObservations(VectorSensor sensor)
    {
        //Debug.Log("Collected Observation");
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(soccerBall.transform.localPosition);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(soccerBall.transform.position.x > 12.5 && soccerBall.transform.position.y < 5.5)
        {
            EndEpisode();
            SetReward(5f);
            scoreBoard.redScore++;
        }
        else if(soccerBall.transform.position.x < -12.5 && soccerBall.transform.position.y < 5.5)
        {
            EndEpisode();
            SetReward(5f);
            scoreBoard.blueScore++;
        }
        if(isKick)
            secondTimer -= Time.deltaTime;
        if(secondTimer <= 0f)
        {
            secondTimer = 1f;
            leg.transform.rotation = Quaternion.Euler(0, 0, 0);
            leg.gameObject.GetComponent<MeshRenderer>().enabled = false;
            leg.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            isKick = false;
        }
        leg.transform.rotation = Quaternion.Lerp(leg.transform.rotation, targetRotation, 10 * rotateTimer * Time.deltaTime);
    }

}
