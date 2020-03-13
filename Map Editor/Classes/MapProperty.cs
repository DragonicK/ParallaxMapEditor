using System;

namespace MapEditor {
    [Serializable]
    public sealed class MapProperty {
        public string Name { get; set; }
        public string Music { get; set; }
        public string Ambience { get; set; }
        public MapLink Link { get; set; }
        public Moral Moral { get; set; }
        public Weather Weather { get; set; }
        public BootMap Boot { get; set; }
        public Fog Fog { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string KeyA { get; set; }
        public string KeyB { get; set; }
        public string KeyC { get; set; }
        public string KeyD { get; set; }

        public MapProperty() {
            Name = string.Empty;
            Music = string.Empty;
            Ambience = string.Empty;

            KeyA = string.Empty;
            KeyB = string.Empty;
            KeyC = string.Empty;
            KeyD = string.Empty;
        }
    }
}