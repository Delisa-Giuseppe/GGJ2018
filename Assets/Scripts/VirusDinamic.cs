using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusDinamic : Enemy
{

    private int maxAngle;
    private Vector3 direction;
    private Vector3 pivot;
    private float startRotation;

    private void Awake()
    {
        maxAngle = Random.Range(90, 361);
        int z = Random.Range(0, 2);
        if (z == 0)
            z = -1;
        direction = new Vector3(0, 0, z);

        startRotation = transform.eulerAngles.z;

        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit);


        pivot = hit.point - (hit.normal * 1f);

        StartCoroutine(CheckDirection());

        //transform.RotateAround(pivot, transform.TransformDirection(direction), speed * Time.deltaTime);

    }

    private void Update()
    {
        MoveEnemy();
    }

    public override void MoveEnemy()
    {

        transform.RotateAround(pivot, transform.TransformDirection(direction), speed * Time.deltaTime);

    }

    IEnumerator CheckDirection()
    {
        if (direction.z > 0)
        {

            if (transform.rotation.eulerAngles.z < maxAngle)
                direction.z = 1;
            else if (transform.rotation.eulerAngles.z > startRotation)
            {
                direction.z = -1;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z < maxAngle)
                direction.z = -1;
            else if (transform.rotation.eulerAngles.z > startRotation)
            {
                direction.z = 1;
            }
        }

        yield return new WaitForSeconds(0.5f);


        StartCoroutine(CheckDirection());

    }
	
}
