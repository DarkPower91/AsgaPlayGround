using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMultiWalker : MonoBehaviour
{
	public BezierSpline spline;

	public float duration;
	public float maxDistance = 5.0f;
	public bool lookForward;
	public SplineWalkerMode mode;
	public Vector3 previousPosition { get { return _previousPosition; } }
	public Quaternion previousRotation { get { return _previousRotation; } }

	private float progress;
	private bool goingForward = true;
	private GameObject player = null;
	protected Vector3 _previousPosition = new Vector3();
	protected Quaternion _previousRotation = new Quaternion();

	public List<GameObject> others = new List<GameObject>();
	public float distance = 0.0f;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		_previousPosition = transform.position;
		_previousRotation = transform.rotation;
	}

	private void FixedUpdate()
	{
		if (player != null && Vector2.Distance(player.transform.position, transform.position) > maxDistance)
		{
			return;
		}

		_previousPosition = transform.position;
		_previousRotation = transform.rotation;

		if (goingForward)
		{
			progress += Time.deltaTime / duration;
			if (progress > 1f)
			{
				if (mode == SplineWalkerMode.Once)
				{
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop)
				{
					progress -= 1f;
				}
				else
				{
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else
		{
			progress -= Time.deltaTime / duration;
			if (progress < 0f)
			{
				progress = -progress;
				goingForward = true;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.position = position;

		if (lookForward)
		{
			Vector3 p = spline.GetDirection(progress);
			float rot_z = Mathf.Atan2(p.y, p.x) * Mathf.Rad2Deg;
			float sign = goingForward ? -1 : 1;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z);//+ sign * 90);
		}

		UpdateChildren();
	}

	private void UpdateChildren()
    {
		if(others.Count > 0)
        {
			Vector3 moveDir = _previousPosition - transform.position;
			moveDir.Normalize();

			Vector3 preDir = others[0].transform.position;
			Quaternion prevRot = others[0].transform.rotation;

			others[0].transform.position = _previousPosition + moveDir * distance;
			others[0].transform.rotation = _previousRotation;

			//++i -> pre incremento -> int ++ () { return i+1; }
 			//i++ -> post incremento ->  int ++() { int j = i; i =i+1; retun j;}

			for(int i = 1; i < others.Count;  ++i)
            {
				Vector3 preDir2 = others[i].transform.position;
				Quaternion prevRot2 = others[i].transform.rotation;

				Vector3 moveDirection = preDir - others[i-1].transform.position;
				moveDirection.Normalize();

				others[i].transform.position = preDir + moveDirection * distance;
				others[i].transform.rotation = prevRot;

				preDir = preDir2;
				prevRot = prevRot2;
            }
        }
    }

}
