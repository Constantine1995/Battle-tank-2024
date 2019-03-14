using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    Text playerHP;

	void Awake ()
    {
        playerHP = GetComponent<Text>();
	}

    public void UpdateHp(float hp)
    {
        playerHP.text = "<color=green> Health: </color>" + hp.ToString();
    }
}
