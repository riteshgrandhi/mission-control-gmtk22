using Assets.Source;
using Assets.Source.Core.EventData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionManager : MonoBehaviour
{
    [SerializeField]
    public MissionInput missionInputPrefab;

    [SerializeField]
    public GameObject awaitingTransmission;

    [SerializeField]
    public MissionTask[] missionTasks;

    private MissionInputData missionInputData;
    private readonly Dictionary<MissionObjective, MissionTaskDoneData> missionObjectiveToMissionTaskMap = new();

    private void OnEnable()
    {
        EventManager.OnCipherInputDone += OnCipherInputDone;
    }

    private void OnDisable()
    {
        EventManager.OnCipherInputDone -= OnCipherInputDone;
    }

    private void OnCipherInputDone(MissionInputData missionInputData)
    {
        Debug.Log("OnCipherInputDone");
        this.missionInputData = missionInputData;
    }

    // Start is called before the first frame update
    void Start()
    {
        Coroutine mainCoroutine = StartCoroutine(StartMainCourotine());
    }

    private IEnumerator StartMainCourotine()
    {
        // show awaiting message
        GameObject instantiatedAwaitingTransmission = Instantiate(awaitingTransmission, this.transform);

        // wait for mission input Done
        yield return StartCoroutine(GetMissionInput(instantiatedAwaitingTransmission));

        foreach (MissionTask missionTask in missionTasks)
        {
            yield return StartCoroutine(StartMissionTask(missionTask, instantiatedAwaitingTransmission, this.missionInputData));
        }

    }

    private IEnumerator StartMissionTask(MissionTask missionTask, GameObject instantiatedAwaitingTransmission, MissionInputData missionInputData)
    {
        yield return new WaitForSeconds(5);

        // hide awaiting message
        instantiatedAwaitingTransmission.SetActive(false);

        GameObject instantiatedMissionTask = Instantiate(missionTask.gameObject, this.transform);

        yield return new WaitUntil(() => this.missionObjectiveToMissionTaskMap.ContainsKey(missionInputData.MissionObjective));

        if (!this.missionObjectiveToMissionTaskMap[missionInputData.MissionObjective].IsSuccess)
        {
            Debug.LogWarning("Failed");
        }

        instantiatedAwaitingTransmission.SetActive(true);
    }

    private IEnumerator GetMissionInput(GameObject instantiatedAwaitingTransmission)
    {
        // wait for 2 seconds
        yield return new WaitForSeconds(2);

        // hide awaiting message
        instantiatedAwaitingTransmission.SetActive(false);

        MissionInput instantiatedMissionInput = Instantiate(missionInputPrefab, this.transform);

        yield return new WaitUntil(() => this.missionInputData != null);

        yield return new WaitForSeconds(10);

        Destroy(instantiatedMissionInput.gameObject);

        instantiatedAwaitingTransmission.SetActive(true);
    }
}
