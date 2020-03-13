using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapEditor {
   public sealed class Database {
        public void Save(string file, object movement) {
            using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write)) {
                var formatter = new BinaryFormatter();

                formatter.Serialize(fs, movement);

                fs.Close();
            }
        }

        public object Open(string file) {
            object movement;

            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read)) {
                var formatter = new BinaryFormatter();

                movement = formatter.Deserialize(fs);

                fs.Close();
            }

            return movement;
        }
    }
}
