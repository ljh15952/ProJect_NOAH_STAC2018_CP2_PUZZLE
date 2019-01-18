using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleFollower : MonoBehaviour
{

    public ParticleSystem ps;

    public float speed;

    public GameObject GoPos;
    public Vector3 CurrentPos;
    Transform myTrans;

    public ParticleSystem.Particle[] particleArray;

    public int numAliveParticle;

    // Use this for initialization
    void Start()
    {
        myTrans = GetComponent<Transform>();
        particleArray = new ParticleSystem.Particle[ps.main.maxParticles];
        CurrentPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoPos)
        {
            numAliveParticle = GoPos.GetComponent<particleFollower>().ps.GetParticles(GoPos.GetComponent<particleFollower>().particleArray);

            for (int i = 0; i < numAliveParticle; i++)
            {
                if (GoPos.transform.position != CurrentPos)
                    GoPos.GetComponent<particleFollower>().particleArray[i].position = GoPos.transform.position;
                else
                {
                    GoPos.GetComponent<particleFollower>().particleArray[i].position = Vector3.MoveTowards(GoPos.GetComponent<particleFollower>().particleArray[i].position, this.transform.position, speed * Time.deltaTime);
                }
            }

            if (GoPos.transform.position != CurrentPos)
                CurrentPos = GoPos.transform.position;

            GoPos.GetComponent<particleFollower>().ps.SetParticles(GoPos.GetComponent<particleFollower>().particleArray, numAliveParticle);

            if (!this.GoPos.CompareTag("SandDown") && !this.GoPos.GetComponent<DragAndDrop>().ishaSand)
            {
                this.gameObject.GetComponent<DragAndDrop>().ishaSand = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        //if (GoPos)
        //{
        //    numAliveParticle = GetComponent<particleFollower>().ps.GetParticles(GetComponent<particleFollower>().particleArray);

        //    for (int i = 0; i < numAliveParticle; i++)
        //    {
        //        if (transform.position != CurrentPos)
        //            GetComponent<particleFollower>().particleArray[i].position = transform.position;
        //        else
        //        {
        //            GetComponent<particleFollower>().particleArray[i].position = Vector3.MoveTowards(GetComponent<particleFollower>().particleArray[i].position, GoPos.transform.position, speed * Time.deltaTime);
        //        }
        //    }

        //    if (transform.position != CurrentPos)
        //        CurrentPos = transform.position;

        //    GetComponent<particleFollower>().ps.SetParticles(GetComponent<particleFollower>().particleArray, numAliveParticle);

        //    if (!this.CompareTag("SandDown") && !this.GetComponent<DragAndDrop>().ishaSand)
        //    {
        //        this.gameObject.GetComponent<DragAndDrop>().ishaSand = false;
        //        this.transform.GetChild(0).gameObject.SetActive(false);
        //    }
        //}
    }
}
