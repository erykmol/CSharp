using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 0f;
	public float spawnMax = 1f;

	void Spawn_()
	{
		int whichPlatform = Random.Range(0,obj.Length);
		GameObject LastSpawnedGround = (GameObject)Instantiate(obj[whichPlatform],transform.position,Quaternion.identity);
		SpriteContainer container = LastSpawnedGround.GetComponent<SpriteContainer>();
        SpriteRenderer lastSprite = container.GetLastSprite;
		if(whichPlatform == 1 || whichPlatform == 2)
		{
			transform.position = new Vector3(lastSprite.bounds.center.x + lastSprite.bounds.size.x,lastSprite.bounds.center.y-0.28f,0);

		}
		else
		{
			transform.position = new Vector3(lastSprite.bounds.center.x + lastSprite.bounds.size.x,lastSprite.bounds.center.y,0);

		}
		//transform.position = new Vector3(lastSprite.bounds.center.x + lastSprite.bounds.size.x,lastSprite.bounds.center.y,0);
		//lastSprite.sprite.bounds.center.y
		
		Invoke("Spawn_", Random.Range(spawnMin,spawnMax));
	}
		

	// Use this for initialization
	void Start () {
		Spawn_();
	}
	
	
}
