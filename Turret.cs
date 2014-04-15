using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour, ITurret
{
	public float damp_ = 6.0f;
	public Transform bulletPrefab_;
	public float nextShotTime_ = 0.0f;
	public float timeBetweenShots_ = 2.0f;
	public float MaxRange_ = 5.0f;
	public int bulletSpeed_ = 1000;
	private string targetTag_ = "Balloon";
	public float zLocation_ = -1.0f;
	public float compensator_ = 5;


	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	public void Update () 
	{
	
		GameObject Target = findClosestTarget ();
		if (Target != null) 
		{
			transform.LookAt (Target.transform.position);	
			if (nextShotTime_ <= Time.time) {
					Debug.Log ("PEW");
					Shoot ();
					nextShotTime_ = Time.time + timeBetweenShots_;
			}
		}
	}
				

	public void Shoot()
	{	
		Vector3 bulletPosition= new Vector3(bulletPrefab_.position.x, bulletPrefab_.position.y, zLocation_); 
		Transform bullet = (Transform)Instantiate(bulletPrefab_, bulletPosition, transform.rotation);
		bullet.rigidbody.AddForce(transform.forward * bulletSpeed_);
	}


	//void Assert(bool condition)
	//{
		//if(!condition)
		//{
		//	Debug.LogError("Error");
		//}

	//}
	public GameObject findClosestTarget()
	{
		GameObject[] allBalloons_= GameObject.FindGameObjectsWithTag(targetTag_);
		float Distance;
		GameObject Target=null;
		int size = allBalloons_.Length;
		int i = 0;
		while (i<size && Target==null) 
		{
			Distance = Vector3.Distance(allBalloons_[i].transform.position, transform.position);
			if (Distance < MaxRange_) 
			{
				Target=allBalloons_[i];
			}
			i++;
		}
		return Target;
	}
}