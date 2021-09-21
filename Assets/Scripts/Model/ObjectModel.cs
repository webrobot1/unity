using UnityEngine;

public class ObjectModel : MonoBehaviour
{
    protected int id;
    protected int map_id;
	public string action = "idle";

	protected Animator anim;

	protected void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void SetData(ObjectJson data)
	{
		if (data.action.Length > 0 && this.action != data.action)
		{
			Debug.Log("Обновляем анимацию " + data.action);

			this.action = data.action;
			anim.SetTrigger(action);
		}

		if (data.map_id > 0)
			this.map_id = data.map_id;

		if (data.position.Length > 0 && this.id == 0)
		{	
			transform.position = new Vector2(data.position[0], data.position[1]);
		}

		if (this.id == 0)
		{
			this.id = data.id;
		}

	}
}
