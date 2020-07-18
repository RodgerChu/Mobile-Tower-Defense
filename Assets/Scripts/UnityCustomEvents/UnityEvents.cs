using UnityEngine.Events;

[System.Serializable]
public class UnityShowTowerInfoEvent : UnityEvent<TowerBuildCell> { }

[System.Serializable]
public class UnityBuildTowerEvent : UnityEvent<TowerBuildCell> { }

[System.Serializable]
public class UnitySpotSelectedEvent : UnityEvent<TowerSpot> { }

[System.Serializable]
public class UnityTowerManagementCellTapEvent : UnityEvent<TowerManagementCellController> { }
