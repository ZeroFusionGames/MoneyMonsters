using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{

	[SerializeField] private Image image;

	private Item _item;
	public Item Item
	{
		get { return _item; }
		set { _item = value;
		if(_item == null)
			{
				image.enabled = false;
			}
		else
			{
				image.sprite = _item.icon;
				image.enabled = true;
			}
		}
	}

	void OnValidate()
	{
		if(image == null)
		{
			image = this.GetComponent<Image>();
		}

	}
}
