using Assets.Source.Core.EventData;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 diceVelocity;
    private Vector3 initialPosition;
    private bool isRollDone;
    public void Awake()
    {
    }

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
        if (!isRollDone && !this.Rigidbody.isKinematic && this.Rigidbody.IsSleeping())
        {
            byte diceNumber = CalculateDiceNumber();
            EventManager.OnRollDiceDoneEvent(new RolledDiceData(diceNumber));
            isRollDone = true;
        }
    }

    private byte CalculateDiceNumber()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform sideCheckerTransform = this.transform.GetChild(i);

            RaycastHit hit;

            Vector3 origin = sideCheckerTransform.position + sideCheckerTransform.forward * 0.2f;

            if (Physics.Raycast(origin, sideCheckerTransform.forward, out hit, 0.9f))
            {
                Debug.DrawRay(origin, sideCheckerTransform.forward * hit.distance, Color.red, 1f);
                int sideValue = sideCheckerTransform.name[^1] - '0';
                Debug.Log(sideValue);
                return (byte)sideValue;
            }
            else
            {
                Debug.DrawRay(origin, sideCheckerTransform.forward * 0.9f, Color.white, 0.5f);
                Debug.Log("Did not Hit");
            }
        }
        return 0;
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
        isRollDone = false;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        this.Rigidbody.isKinematic = true;
    }
}
