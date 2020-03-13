using System.IO;

namespace MapEditor.Export {
    public sealed class ExportServer {
        private Map Map { get; set; }

        public ExportServer(Map map) {
            Map = map;
        }

        public void SaveFile(string fileName) {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                using (var binary = new BinaryWriter(fs)) {
                    binary.Write(Map.Property.Name);
                    binary.Write(Map.Property.Music);
                    binary.Write(Map.Property.Ambience);

                    binary.Write(Map.Property.Link.Up);
                    binary.Write(Map.Property.Link.Down);
                    binary.Write(Map.Property.Link.Left);
                    binary.Write(Map.Property.Link.Right);

                    binary.Write((byte)Map.Property.Moral);
                    binary.Write((byte)Map.Property.Weather);

                    binary.Write(Map.Property.Boot.Id);
                    binary.Write(Map.Property.Boot.X);
                    binary.Write(Map.Property.Boot.Y);

                    binary.Write(Map.Property.Width - 1);
                    binary.Write(Map.Property.Height - 1);

                    for (var x = 0; x < Map.Property.Width; x++) {
                        for (var y = 0; y < Map.Property.Height; y++) {
                            binary.Write((byte)Map.Tile[x, y].Type);
                            binary.Write(Map.Tile[x, y].Data1);
                            binary.Write(Map.Tile[x, y].Data2);
                            binary.Write(Map.Tile[x, y].Data3);
                            binary.Write(Map.Tile[x, y].Data4);
                            binary.Write(Map.Tile[x, y].Data5);
                            binary.Write(Map.Tile[x, y].DirBlock);
                        }
                    }

                    binary.Close();
                    fs.Close();
                }
            }     
        }
    }
}
