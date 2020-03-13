using System;
using System.Collections.Generic;

namespace MapEditor {
    [Serializable]
    public sealed class Map {
        public bool Resizing { get; set; }
        public MapProperty Property { get; set; }
        public Tile[,] Tile { get; set; }
        public List<Parallax> Ground { get; set; }
        public List<Parallax> Fringe { get; set; }

        public Map() {
            Property = new MapProperty();
            Ground = new List<Parallax>();
            Fringe = new List<Parallax>();

            Tile = new Tile[1, 1];
            Tile[0, 0] = new Tile();
        }

        public void UpdatSize() {
            Resizing = true;

            UpdateTileSize();

            var ground =  UpdateTerrain(Ground);
            var fringe = UpdateTerrain(Fringe);

            Ground = ground;
            Fringe = fringe;

            Resizing = false;
        }

        private void UpdateTileSize() {
            var tile = new Tile[Property.Width, Property.Height];
            var dimension_x = Tile.GetUpperBound(0);
            var dimension_y = Tile.GetUpperBound(1);

            for (var x = 0; x < Property.Width; x++) {
                for (var y = 0; y < Property.Height; y++) {

                    if (x <= dimension_x && y <= dimension_y) {
                        tile[x, y] = Tile[x, y].Clone();
                    }
                    else {
                        tile[x, y] = new Tile();
                    }
                }
            }

            Tile = tile;
        }

        private List<Parallax> UpdateTerrain(List<Parallax> parallaxes) {
            // Create a new list.
            var list = CreateParallaxList();

            int old_x;
            int old_y;

            //// Copy to list.
            if (parallaxes.Count > 0) {
                for (var i = 0; i < parallaxes.Count; i++) {
                    var item = parallaxes[i];

                    // Find Item and copy data.
                    for (var n = 0; n < list.Count; n++) {
                        if (list[n].Id == item.Id) {
                            old_x = list[n].X;
                            old_y = list[n].Y;

                            list[n] = item.Clone();

                            list[n].X = old_x;
                            list[n].Y = old_y;
                        }
                    }
                }
            }

            return list;
        }

        private List<Parallax> CreateParallaxList() {
            var list = new List<Parallax>();
            var count = 0;

            var total_x = Property.Width * 32;
            var total_y = Property.Height * 32;

            var count_x = total_x / 256;
            var count_y = total_y / 256;

            if (total_x % 256 > 0) {
                count_x++;
            }

            if (total_y % 256 > 0) {
                count_y++;
            }

            for (var x = 0; x < count_x; x++) {
                for (var y = 0; y < count_y; y++) {

                    count++;

                    var parallax = new Parallax() {
                        Id = count,
                        X = x * 256,
                        Y = y * 256,
                        Bitmap = null
                    };

                    list.Add(parallax);
                }
            }

            return list;
        }
    }
}