using System;
using System.Drawing;

namespace MapEditor {
    [Serializable]
    public sealed class Parallax {
        public int Id { get; set; }
        public string Name { get; set; }
        public Bitmap Bitmap { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Parallax() {
            Name = "Empty";
        }

        public Parallax Clone() {
            var parallax = new Parallax() {
                Id = Id,
                Name = Name
            };

            if (Bitmap != null) {
                parallax.Bitmap = new Bitmap(Bitmap);
            }

            return parallax;
        }
    }
}