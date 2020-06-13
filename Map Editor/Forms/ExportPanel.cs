using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MapEditor.Export;

namespace MapEditor {
    public partial class ExportPanel : Form {
        private Map Map { get; set; }

        public ExportPanel() {
            InitializeComponent();
        }

        public void Show(Map map) {
            Map = map;

            Show();
        }

         private void ButtonConfirm_Click(object sender, EventArgs e) {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Exported\")) {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Exported\");
            }

            var dialog = new SaveFileDialog() {
                InitialDirectory = Environment.CurrentDirectory + @"\Exported\",
                Filter = "Engine Game Maps (*.maps) | *.maps",
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                //var export = new ExportHandler(key, iv);
                //var saved = export.SaveMap(Map, dialog.FileName);

                //var toServer = new ExportServer(Map);
                //toServer.SaveFile(CreateServerFileName(dialog.FileName));

                //if (!saved) {
                //    MessageBox.Show("There was an error while opening the file.");
                //}
            }
        }

        private string CreateServerFileName(string fileName) {
            return fileName.Replace(".maps", ".dat");
        }
    }
}
