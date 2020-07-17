using UnityEngine.Events;

[System.Serializable]
public class UnityShowTowerInfoEvent : UnityEvent<TowerBuildCell> { }

[System.Serializable]
public class UnityBuildTowerEvent : UnityEvent<TowerBuildCell> { }