using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeSpawner : MonoBehaviour
{
    public GameObject grenadePrefab;
    public void spawn(){
	Instantiate(grenadePrefab, transform);
    }
}
