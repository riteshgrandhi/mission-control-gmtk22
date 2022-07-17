namespace Assets.Source.Core.EventData
{
    class MissionTaskDoneData
    {
        public MissionTaskDoneData(MissionObjective missionObjective, bool isSuccess)
        {
            MissionObjective = missionObjective;
            IsSuccess = isSuccess;
        }

        public MissionObjective MissionObjective { get; }
        public bool IsSuccess { get; }
    }
}
