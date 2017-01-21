using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour
{
	IEnumerator Start ()
    {
        for(int i = 0; i < 25; i++)
        {
            transform.localScale += new Vector3(1, 1, 0);
            yield return new WaitForSeconds(.05f);
        } 
	}
}
