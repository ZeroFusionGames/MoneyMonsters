using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SeedGenerator))]
public class ChestOpener : Interactable
{
	[Header("Chest settings")]
	public Gradient gradientColour;
	[Range(0f,1f)]
	public float rarity;
	public Animator anim;
	public Transform itemSpawnLocation;
	private SeedGenerator SeedGen;
	public int seed;
	[SerializeField]
	private AudioSource chestAudio;


	public void Start()
	{
		base.Start();
		SeedGen = this.gameObject.GetComponent<SeedGenerator>();
		seed = SeedGen.seed;
		
	}

	public override void Interact()
	{
		base.Interact();
		Random.InitState(seed);
		if (anim != null)
		{
			chestAudio.Play();
			anim.Play("Opening");
		}
		Material chestMat = this.GetComponent<Renderer>().material;
		chestMat.SetColor("_BaseColor", gradientColour.Evaluate(rarity));
		Destroy(this.GetComponent<HighlightOnSelect>());
		rarity = Random.Range(0f, 1f);
		Debug.Log(rarity);
	}
}
