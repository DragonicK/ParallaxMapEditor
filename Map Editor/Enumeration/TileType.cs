using System;

namespace MapEditor {
    [Serializable]
    public enum TileType {
        Walkable,
        Blocked,
        Warp,
        NpcAvoid,
        Heal,
        Trap,
        Chat
    }
}