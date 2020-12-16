using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    int playerNum;

	public PlayerInput(int aPlayerNum)
	{
		playerNum = aPlayerNum;
	}

	public Vector2 GetInput_LeftStick()
	{
		return new Vector2(Input.GetAxis("Player" + playerNum + "Horizontal"), Input.GetAxis("Player" + playerNum + "Vertical"));
	}

	public Vector2 GetInput_RightStick()
	{
		return new Vector2(Input.GetAxis("Player" + playerNum + "HorizontalR"), Input.GetAxis("Player" + playerNum + "VerticalR"));
	}

	public float GetFire()
	{
		return Input.GetAxis("Player" + playerNum + "RightTrigger");
	}

	public float GetShield()
	{
		return Input.GetAxis("Player" + playerNum + "LeftTrigger");
	}
}
