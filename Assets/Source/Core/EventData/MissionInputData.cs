using System.Collections.Generic;

namespace Assets.Source.Core.EventData
{
    public enum MissionObjective
    {
        MISSILE,
        SEND_GETAWAY,
        SEND_DRONE,
    }
    public class MissionInputData
    {
        public string MissionName { get; }
        public MissionObjective MissionObjective { get; }
        public Dictionary<byte, string> CipherToCodewordMap { get; }
        public Dictionary<string, byte> CodewordToCipherMap { get; }

        public MissionInputData(string missionName, MissionObjective missionObjective, Dictionary<byte, string> cipherToCodewordMap, Dictionary<string, byte> codewordToCipherMap)
        {
            MissionName = missionName;
            MissionObjective = missionObjective;
            CipherToCodewordMap = cipherToCodewordMap;
            CodewordToCipherMap = codewordToCipherMap;
        }
    }
}
