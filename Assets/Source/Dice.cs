using Assets.Source.Core.EventData;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 diceVelocity;
    private Vector3 initialPosition;

    private Rigidbody Rigidbody
    {
        get
        {
            if (_rb == null) _rb = GetComponent<Rigidbody>();
            return _rb;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.diceVelocity = this.Rigidbody.velocity;
    }


    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {
        EventManager.OnRollDice += OnRollDice;
    }

    private void OnDisable()
    {
        EventManager.OnRollDice -= OnRollDice;
    }

    private void OnRollDice()
    {
        this.Reset();
        this.Rigidbody.isKinematic = false;
        this.Rigidbody.AddForce(transform.forward * 1000);
        this.Rigidbody.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    private void Reset()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        this.Rigidbody.isKinematic = true;
    }
}
