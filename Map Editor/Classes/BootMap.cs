using System;

namespace MapEditor {
    [Serializable]
    public struct BootMap {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}