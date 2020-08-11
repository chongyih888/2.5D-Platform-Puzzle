using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;

    private int _requiredCoins = 8;

    private Elevator _elevator;

    private bool _elevatorCalled = false;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if(_elevator == null)
        {
            Debug.LogError("The Elevator is NULL.");
        }
    }

    //detect trigger collision
    //check for player
    //if e key is pressed
    //turn the light = blue

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {


            if (Input.GetKeyDown(KeyCode.E) && other.transform.GetComponent<Player>().CollectedCoins() >=  _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                }
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;                  
                }

                _elevator.CallElevator();
            }
        }
    }
}
