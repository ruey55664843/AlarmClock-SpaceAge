using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	public Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * Random.Range(5f,15f);
	}
}
