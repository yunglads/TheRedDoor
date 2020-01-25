using UnityEngine;


public class IKControl : MonoBehaviour {

	private Animator animator;
	public bool ikActive = false;
    public Transform lookObj = null;
    //public GameObject[] players;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}

    void Update()
    {
        FindClosestPlayer();
    }

    void OnAnimatorIK()
	{
	  if(ikActive)
      {             
       if (lookObj != null)
       {
         animator.SetLookAtWeight(1, 1, 1, 1, 1);                        
         animator.SetLookAtPosition(lookObj.position);
       }
	  }			
	}

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
