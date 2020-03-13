using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MapEditor {
    public partial class Main : Form {
        const int MaxGridViewValueX = 0;
        const int MaxGridViewValueY = 0;

        const int DefaultMaxX = 24;
        const int DefaultMaxY = 16;

        const int TileSize = 256;
        const int PicSize = 32;
        const int MaxDirections = 4;
        const int DirectionImageSize = 8;

        bool ViewGridTile = true;
        bool viewGridParallax = true;
        bool ViewGround = true;
        bool ViewFringe = true;
        bool ViewParallaxName = true;
        bool ViewParallaxId = true;

        int StartX;
        int StartY;

        string ProjectPath = string.Empty;
        string SafeFileName = "NoTitle.mps";

        Point[] DirectionPositions;

        Bitmap TextureDirection { get; set; }
        Map Map { get; set; }

        ExportPanel panel;
        Property property;
        Pen coral_pen;
        Pen white_pen;

        readonly SolidBrush brushes_red = new SolidBrush(Color.FromArgb(60, Color.Red));
        readonly SolidBrush brushes_skyblue = new SolidBrush(Color.FromArgb(60, Color.SkyBlue));
        readonly SolidBrush brushes_magenta = new SolidBrush(Color.FromArgb(60, Color.Magenta));
        readonly SolidBrush brushes_gold = new SolidBrush(Color.FromArgb(60, Color.Gold));
        readonly SolidBrush brushes_aquamarine = new SolidBrush(Color.FromArgb(60, Color.Aquamarine));
         
        Font font;

        const string TextMissing = "File is missing: direction.png";
        const string DirectionImageFilePath = "./Data Files/direction.png";

        public Main() {
            InitializeComponent();

            panel = new ExportPanel();
            property = new Property();
            coral_pen = new Pen(Brushes.Coral, 3);
            white_pen = new Pen(Brushes.White, 1);
            font = new Font("Consolas", 11);

            Map = new Map();
            Map.Property.Width = DefaultMaxX + 1;
            Map.Property.Height = DefaultMaxY + 1;
            UpdateSize();

            LoadTextureDirection();
            SetDirectionPositions();
        }

        private void Main_Load(object sender, EventArgs e) {
            UpdateTitle();
        }

        private static bool IsDirBlocked(uint blockVar, int dir) {
            var dirResult = Convert.ToUInt32(Math.Pow(2, dir));
            var result = (~blockVar & dirResult);

            if (Convert.ToBoolean(result)) {
                return false;
            }

            return true;
        }

        private static void SetDirBlocked(ref uint blockVar, int dir, bool block) {
            var dirResult = Convert.ToUInt32(Math.Pow(2, dir));
            uint value;
             
            if (block) {
                value = blockVar | dirResult;
            }  
            else {
                value = blockVar & ~dirResult;
            }

            blockVar = value;
        }

        public void UpdateSize() {
            var value_x = Map.Property.Width - MaxGridViewValueX;
            var value_y = Map.Property.Height - MaxGridViewValueY;

            if (value_x < 0) {
                value_x = 0;
            }

            if (value_y < 0) {
                value_y = 0;
            }

            if (StartX > value_x) {
                StartX = value_x;
            }

            if (StartY > value_y) {
                StartY = value_y;
            }

            ScrollStartX.Maximum = value_x;
            ScrollStartY.Maximum = value_y;
            ScrollStartX.Value = StartX;
            ScrollStartY.Value = StartY;

            LabelX.Text = "X: " + StartX;
            LabelY.Text = "Y: " + StartY;

            Map.UpdatSize();
            PictureMap.Invalidate();
        }

        #region Direction Positions

        private void SetDirectionPositions() {
            DirectionPositions = new Point[MaxDirections];

            DirectionPositions[(int)Direction.Up].X = 12;
            DirectionPositions[(int)Direction.Up].Y = 0;

            DirectionPositions[(int)Direction.Down].X = 12;
            DirectionPositions[(int)Direction.Down].Y = 24;

            DirectionPositions[(int)Direction.Left].X = 0;
            DirectionPositions[(int)Direction.Left].Y = 12;

            DirectionPositions[(int)Direction.Right].X = 24;
            DirectionPositions[(int)Direction.Right].Y = 12;
        }

        #endregion

        #region Texture Direction

        private void LoadTextureDirection() {
            if (File.Exists(DirectionImageFilePath)) {
                TextureDirection = new Bitmap(DirectionImageFilePath);           
            }
            else {
                MessageBox.Show(TextMissing);
            }
        }

        #endregion

        #region Menu

        private void UpdateTitle() {
            Text = $"Map Editor - {SafeFileName}";
        }

        private void MenuOpen_Click(object sender, EventArgs e) {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Project\")) {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Project\");
            }

            var dialog = new OpenFileDialog() {
                InitialDirectory = Environment.CurrentDirectory + @"\Project\",
                Filter = "Engine Maps (*.mps) | *.mps",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var db = new Database();
                Map = (Map)db.Open(dialog.FileName);

                ProjectPath = dialog.FileName;
                SafeFileName = dialog.SafeFileName;

                UpdateTitle();
                UpdateSize();
            }

            PictureMap.Invalidate();
        }

        private void MenuSave_Click(object sender, EventArgs e) {
            var db = new Database();
 
            if (ProjectPath.Length == 0) {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Project\")) {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Project\");
                }

                var dialog = new SaveFileDialog() {
                    InitialDirectory = Environment.CurrentDirectory + @"\Project\",
                    Filter = "Engine Maps (*.mps) | *.mps",
                    FilterIndex = 0
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    db.Save(dialog.FileName, Map);
                    ProjectPath = dialog.FileName;

                    var names = ProjectPath.Split('\\');
                    SafeFileName = names[names.GetUpperBound(0)];
                    UpdateTitle();
                }
            }
            else {
                db.Save(ProjectPath, Map);
            }
        }

        private void MenuSaveAs_Click(object sender, EventArgs e) {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Project\")) {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Project\");
            }

            var dialog = new SaveFileDialog() {
                InitialDirectory = Environment.CurrentDirectory + @"\Project\",
                Filter = "Engine Maps (*.mps) | *.mps",
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var db = new Database();
                db.Save(dialog.FileName, Map);
                ProjectPath = dialog.FileName;

                var names = ProjectPath.Split('\\');
                SafeFileName = names[names.GetUpperBound(0)];

                UpdateTitle();
            }
        }

        private void MenuExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void MenuProperty_Click(object sender, System.EventArgs e) {
            if (property.IsDisposed) {
                property = new Property();
            }

            property.Show(this, Map.Property);
        }

        private void MenuGridViewTile_Click(object sender, EventArgs e) {
            ViewGridTile = MenuGridViewTile.Checked;
            PictureMap.Invalidate();
        }

        private void MenuGridViewParallax_Click(object sender, EventArgs e) {
            viewGridParallax = MenuGridViewParallax.Checked;
            PictureMap.Invalidate();
        }

        private void MenuGroundView_Click(object sender, EventArgs e) {
            ViewGround = MenuGroundView.Checked;
            PictureMap.Invalidate();
        }

        private void MenuFringeView_Click(object sender, EventArgs e) {
            ViewFringe = MenuFringeView.Checked;
            PictureMap.Invalidate();
        }

        private void MenuParallaxName_Click(object sender, EventArgs e) {
            ViewParallaxName = MenuParallaxName.Checked;
            PictureMap.Invalidate();
        }

        private void MenuParallaxId_Click(object sender, EventArgs e) {
            ViewParallaxId = MenuParallaxId.Checked;
            PictureMap.Invalidate();
        }

        private void MenuCreateMap_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog() {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Image Files (*.png) | *.png",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                if (RadioGround.Checked || RadioFringe.Checked) {
                    CreateMapFromImage(dialog.FileName, dialog.SafeFileName);
                }
            }  
        }

        private void MenuCreateFolder_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog() {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Image Files (*.png) | *.png",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                CreateMapFolderFromImage(dialog.FileName, dialog.SafeFileName);         
            }
        }

        #endregion

        #region Picture Map

        private void PictureMap_Paint(object sender, PaintEventArgs e) {
            var PictureWidth = PictureMap.Width;
            var PictureHeight = PictureMap.Height;

            var g = e.Graphics;
            g.Clear(Color.Black);

            if (ViewGround) {
                DrawGround(ref g);
            }

            if (ViewFringe) {
                DrawFringe(ref g);
            }

            if (RadioAttributes.Checked || RadioDirection.Checked) {
                DrawAttributes(ref g);
            }

            if (RadioDirection.Checked) {
                DrawDirection(ref g);
            }

            if (ViewGridTile) {
                DrawTileLines(ref g, PictureWidth, PictureHeight);
            }

            if (viewGridParallax) {
                DrawParallaxLines(ref g, PictureWidth, PictureHeight);
            }
        }

        private void PictureMap_MouseDown(object sender, MouseEventArgs e) {         
            var clicked_x = ((StartX * PicSize) + e.X) / TileSize;
            var clicked_y = ((StartY * PicSize) + e.Y) / TileSize;
            var clicked_tile = GetClickedAreaIndex(clicked_x, clicked_y);
            var x = (e.X / PicSize) + StartX;
            var y = (e.Y / PicSize) + StartY;

            if (RadioGround.Checked) {
                if (e.Button == MouseButtons.Left) {
                    OpenParallaxImage(Map.Ground, clicked_tile);
                }
                else if (e.Button == MouseButtons.Right) {
                    Map.Ground[clicked_tile].Bitmap = null;
                    Map.Ground[clicked_tile].Name = "Empty";
                }
            }
            else if (RadioFringe.Checked) {
                if (e.Button == MouseButtons.Left) {
                    OpenParallaxImage(Map.Fringe, clicked_tile);
                }
                else if (e.Button == MouseButtons.Right) {
                    Map.Fringe[clicked_tile].Bitmap = null;
                    Map.Fringe[clicked_tile].Name = "Empty";
                }
            }
            else if (RadioAttributes.Checked) {
                if (e.Button == MouseButtons.Left) {
                    SelectAttribute(x, y);
                }
                else if (e.Button == MouseButtons.Right) {
                    DiselectAttribute(x, y);
                }
            }
            else if (RadioDirection.Checked) {
                if (e.Button == MouseButtons.Left) {
                    SetDirection(x, y, e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Right) {

                }
            }

            PictureMap.Invalidate();
        }

        private int GetClickedAreaIndex(int clicked_x, int clicked_y) {
            var total_x = Map.Property.Width * 32;
            var total_y = Map.Property.Height * 32;

            var count_x = total_x / 256;
            var count_y = total_y / 256;

            if (total_x % 256 > 0) {
                count_x++;
            }

            if (total_y % 256 > 0) {
                count_y++;
            }

            var count = -1;

            for (var x = 0; x < count_x; x++) {
                for (var y = 0; y < count_y; y++) {
                    count++;

                    if (x == clicked_x && y == clicked_y) {
                        return count;
                    }
                }
            }

            return count;
        }

        private void OpenParallaxImage(List<Parallax> list, int index) {
            var dialog = new OpenFileDialog() {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Image Files (*.png) | *.png",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                FilterIndex = 0
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var bitmap = new Bitmap(dialog.FileName);

                list[index].Bitmap = bitmap;
                list[index].Name = dialog.SafeFileName;

                PictureMap.Invalidate();
            }
        }

        #endregion

        #region Set Attributes

        private void SelectAttribute(int x, int y) {
            SetAttributeValue(x, y, true);
        }

        private void DiselectAttribute(int x, int y) {
            SetAttributeValue(x, y, false);
        }

        private void SetAttributeValue(int x, int y, bool add) {
            var tileType = TileType.Walkable;

            if (RadioBlock.Checked) {
                tileType = TileType.Blocked;
            }
            else if (RadioAvoid.Checked) {
                tileType = TileType.NpcAvoid;
            }
            else if (RadioTrap.Checked) {
                tileType = TileType.Trap;
            }
            else if (RadioChat.Checked) {
                tileType = TileType.Chat;
            }
            else if (RadioWarp.Checked) {
                tileType = TileType.Warp;
            }

            if (add) {
                Map.Tile[x, y].Type = tileType;
            }
            else {
                Map.Tile[x, y].Type = 0;
                Map.Tile[x, y].Data1 = 0;
                Map.Tile[x, y].Data2 = 0;
                Map.Tile[x, y].Data3 = 0;
                Map.Tile[x, y].Data4 = 0;
                Map.Tile[x, y].Data5 = 0;
            }
        }

        #endregion

        #region Set Direction
        private void SetDirection(int clicked_x, int clicked_y, int mouseX, int mouseY) {
            var x = mouseX - (clicked_x * PicSize);
            var y = mouseY - (clicked_y * PicSize);

            for (var i = 0; i < MaxDirections; i++) {
                if (x >= DirectionPositions[i].X && x <= DirectionPositions[i].X + DirectionImageSize) {
                    if (y >= DirectionPositions[i].Y && y <= DirectionPositions[i].Y + DirectionImageSize) {

                        var value = Convert.ToUInt32(Map.Tile[clicked_x, clicked_y].DirBlock);
                        SetDirBlocked(ref value, i, !IsDirBlocked(value, i));
                        Map.Tile[clicked_x, clicked_y].DirBlock = (byte)value;

                        return;
                    }
                }
            }
        }

        #endregion

        #region Draw Lines

        private void DrawTileLines(ref Graphics g, int pictureWidth, int pictureHeight) {
            var start_x = 0;
            var start_y = 0;
            var x_count = PictureMap.Width / 32;
            var y_count = PictureMap.Height / 32;

            for (var x = 0; x < x_count; x++) {
                for (var y = 0; y < y_count; y++) {
                    // Horizontal.
                    g.DrawLine(white_pen, start_x, y * PicSize, pictureWidth, y * PicSize);
                    // Vertical.
                    g.DrawLine(white_pen, x * PicSize, start_y, x * PicSize, pictureHeight);
                }
            }
        }

        private void DrawParallaxLines(ref Graphics g, int pictureWidth, int pictureHeight) {
            var Count = 3;
            var start_x = 0;
            var start_y = 0;

            for (var i = 1; i <= Count; i++) {
                // Horizontal.
                g.DrawLine(coral_pen, start_x, (start_y + TileSize) * i, pictureWidth, (start_y + TileSize) * i);
                // Vertical.
                g.DrawLine(coral_pen, (start_x + TileSize) * i, start_y, (start_x + TileSize) * i, pictureHeight);
            }
        }

        #endregion

        #region Draw Ground

        private void DrawGround(ref Graphics g) {
            var source = new Rectangle() {
                X = 0,
                Y = 0,
                Width = TileSize,
                Height = TileSize
            };

            var destination = new Rectangle() {
                Width = TileSize,
                Height = TileSize
            };

            int width = StartX * PicSize;
            int height = StartY * PicSize;

            for (var i = 0; i < Map.Ground.Count; i++) {
                destination.X = Map.Ground[i].X - width;
                destination.Y = Map.Ground[i].Y - height;

                if (Map.Ground[i].Bitmap != null) {
                    g.DrawImage(Map.Ground[i].Bitmap, destination, source, GraphicsUnit.Pixel);
                }

                if (!GroupAttributes.Enabled && !RadioDirection.Checked) {
                    if (ViewParallaxId) {
                        g.DrawString("Ground Id: " + Map.Ground[i].Id, font, Brushes.White, destination.X, destination.Y);
                    }

                    if (ViewParallaxName) {
                        destination.Y = Map.Ground[i].Y - height + TileSize - (PicSize * 2);
                        g.DrawString("Ground: " + Map.Ground[i].Name, font, Brushes.White, destination.X, destination.Y);
                    }
                }
            }
        }

        #endregion

        #region Draw Fringe
        private void DrawFringe(ref Graphics g) {
            var source = new Rectangle() {
                X = 0,
                Y = 0,
                Width = TileSize,
                Height = TileSize
            };

            var destination = new Rectangle() {
                Width = TileSize,
                Height = TileSize
            };

            int width = StartX * PicSize;
            int height = StartY * PicSize;

            for (var i = 0; i < Map.Fringe.Count; i++) {
                destination.X = Map.Fringe[i].X - width;
                destination.Y = Map.Fringe[i].Y - height;

                if (Map.Fringe[i].Bitmap != null) {
                    g.DrawImage(Map.Fringe[i].Bitmap, destination, source, GraphicsUnit.Pixel);
                }

                if (!GroupAttributes.Enabled && !RadioDirection.Checked) {
                    if (ViewParallaxId) {
                        destination.Y = Map.Fringe[i].Y - height + PicSize;
                        g.DrawString("Fringe Id: " + Map.Fringe[i].Id, font, Brushes.White, destination.X, destination.Y);
                    }

                    if (ViewParallaxName) {
                        destination.Y = Map.Fringe[i].Y - height + TileSize - PicSize;
                        g.DrawString("Fringe: " + Map.Fringe[i].Name, font, Brushes.White, destination.X, destination.Y);
                    }
                }
            }
        }

        #endregion

        #region Draw Attributes

        private void DrawAttributes(ref Graphics g) {
            var x_count = PictureMap.Width / 32;
            var y_count = PictureMap.Height / 32;

            TileType tileType;
            int tile_x;
            int tile_y;

            for (var x = 0; x < x_count; x++) {
                for (var y = 0; y < y_count; y++) {

                    tile_x = x + StartX;
                    tile_y = y + StartY;

                    if (tile_x >= Map.Property.Width) {
                        tile_x = Map.Property.Width - 1;
                    }

                    if (tile_y >= Map.Property.Height) {
                        tile_y = Map.Property.Height - 1;
                    }

                    // Se houver somente um único tile no mapa.
                    // Não permite que fique fora do índice.
                    if (tile_x < 0) {
                        tile_x = 0;
                    }

                    if (tile_y < 0) {
                        tile_y = 0;
                    }

                    tileType = (TileType)Map.Tile[tile_x, tile_y].Type;
                  
                    if (!Map.Resizing) {
                        DrawAttribute(ref g, tileType, x, y);
                    }
                }
            }
        }

        private void DrawAttribute(ref Graphics g, TileType tileType, int x, int y) {
            var letter = string.Empty;
            var brushes = Brushes.White;
            var fill = Brushes.Transparent;

            switch(tileType) {
                case TileType.Blocked:
                    letter = "B";
                    brushes = Brushes.Red;
                    fill = brushes_red;

                    break;
                case TileType.Warp:
                    letter = "W";
                    brushes = Brushes.SkyBlue;
                    fill = brushes_skyblue;

                    break;
                case TileType.Trap:
                    letter = "T";
                    brushes = Brushes.Magenta;
                    fill = brushes_magenta;

                    break;
                case TileType.NpcAvoid:
                    letter = "A";
                    brushes = Brushes.Gold;
                    fill = brushes_gold;

                    break;
                case TileType.Chat:
                    letter = "C";
                    brushes = Brushes.Aquamarine;
                    fill = brushes_aquamarine;
                    break;
            }

            if (tileType != TileType.Walkable) {
                g.FillRectangle(fill, new RectangleF(x * PicSize, y * PicSize, PicSize, PicSize));
            }

            g.DrawString(letter, font, brushes, 9 + (x * PicSize), 8 + (y * PicSize));

        }

        #endregion

        #region Draw Direction
        private void DrawDirection(ref Graphics g) {
            var destination = new Rectangle() {
                Width = DirectionImageSize,
                Height = DirectionImageSize
            };

            var source = new Rectangle {
                Width = DirectionImageSize,
                Height = DirectionImageSize
            };

            var x_count = PictureMap.Width / 32;
            var y_count = PictureMap.Height / 32;

            int tile_x;
            int tile_y;

            for (var x = 0; x <= x_count; x++) {
                for (var y = 0; y <= y_count; y++) {
                    for (var i = 0; i < MaxDirections; i++) {
                        destination.X = x * PicSize + DirectionPositions[i].X;
                        destination.Y = y * PicSize + DirectionPositions[i].Y;

                        source.X = i * DirectionImageSize;

                        tile_x = x + StartX;
                        tile_y = y + StartY;

                        if (tile_x >= Map.Property.Width) {
                            tile_x = Map.Property.Width - 1;
                        }

                        if (tile_y >= Map.Property.Height) {
                            tile_y = Map.Property.Height - 1;
                        }

                        // Se houver somente um único tile no mapa.
                        // Não permite que fique fora do índice.
                        if (tile_x < 0) {
                            tile_x = 0;
                        }

                        if (tile_y < 0) {
                            tile_y = 0;
                        }

                        if (!Map.Resizing) {
                            // i = Direction
                            if (IsDirBlocked(Map.Tile[tile_x, tile_y].DirBlock, i)) {
                                source.Y = DirectionImageSize * 2;
                            }
                            else {
                                source.Y = DirectionImageSize;
                            }

                            g.DrawImage(TextureDirection, destination, source, GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }

        #endregion

        #region Scroll X, Y

        private void ScrollStartX_Scroll(object sender, ScrollEventArgs e) {
            StartX = ScrollStartX.Value;
            LabelX.Text = "X: " + StartX;
            PictureMap.Invalidate();
        }

        private void ScrollStartY_Scroll(object sender, ScrollEventArgs e) {
            StartY = ScrollStartY.Value;
            LabelY.Text = "Y: " + StartY;
            PictureMap.Invalidate();
        }

        #endregion

        #region Radio Button Invalidate

        private void RadioGround_CheckedChanged(object sender, EventArgs e) {
            GroupAttributes.Enabled = false;
            ButtonClearDirection.Enabled = false;
            MenuCreateMap.Enabled = true;
            PictureMap.Invalidate();
        }

        private void RadioFringe_CheckedChanged(object sender, EventArgs e) {
            GroupAttributes.Enabled = false;
            ButtonClearDirection.Enabled = false;
            MenuCreateMap.Enabled = true;
            PictureMap.Invalidate();
        }

        private void RadioAttributes_CheckedChanged(object sender, EventArgs e) {
            GroupAttributes.Enabled = true;
            ButtonClearDirection.Enabled = false;
            MenuCreateMap.Enabled = false;
            PictureMap.Invalidate();
        }

        private void RadioDirection_CheckedChanged(object sender, EventArgs e) {
            GroupAttributes.Enabled = false;
            ButtonClearDirection.Enabled = true;
            MenuCreateMap.Enabled = false;
            PictureMap.Invalidate();
        }

        #endregion

        #region Clear Attributes

        private void ButtonClearAttribute_Click(object sender, EventArgs e) {
            ClearAttributes();
        }

        private void ClearAttributes() {
            for(var x = 0; x < Map.Property.Width; x++) {
                for (var y = 0; y < Map.Property.Height; y++) {
                    ClearAttribute(x, y);
                }
            }

            PictureMap.Invalidate();
        }

        private void ClearAttribute(int x, int y) {
            Map.Tile[x, y].Type = TileType.Walkable;
            Map.Tile[x, y].Data1 = 0;
            Map.Tile[x, y].Data2 = 0;
            Map.Tile[x, y].Data3 = 0;
            Map.Tile[x, y].Data4 = 0;
            Map.Tile[x, y].Data5 = 0;
        }

        #endregion

        #region Clear Directions

        private void ButtonClearDirection_Click(object sender, EventArgs e) {
            ClearDirections();
        }

        private void ClearDirections() {
            for (var x = 0; x < Map.Property.Width; x++) {
                for (var y = 0; y < Map.Property.Height; y++) {
                    ClearDirection(x, y);
                }
            }

            PictureMap.Invalidate();
        }

        private void ClearDirection(int x, int y) {
            Map.Tile[x, y].DirBlock = 0;
        }

        #endregion

        #region Create Map From Image

        private void CreateMapFromImage(string fileName, string safeFileName) {
            var bitmap = new Bitmap(fileName);

            var count_x = bitmap.Width / PicSize;
            var count_y = bitmap.Height / PicSize;

            var tile_count_x = bitmap.Width / TileSize;
            var tile_count_y = bitmap.Height / TileSize;

            if (count_x <= 0) {
                ShowInvalidImage();
                return;
            }

            if (count_y <= 0) {
                ShowInvalidImage();
                return;
            }

            if (bitmap.Width % PicSize > 0) {
                count_x++;
            }

            if (bitmap.Height % PicSize > 0) {
                count_y++;
            }

            if (bitmap.Width % TileSize > 0) {
                tile_count_x++;
            }

            if (bitmap.Height % TileSize > 0) {
                tile_count_y++;
            }

            Map.Property.Width = count_x;
            Map.Property.Height = count_y;

            UpdateSize();

            var count = 0;
            Bitmap new_bitmap;

            CreateMapFolder(GetCompleteFolder(GetFolderName(safeFileName)));
            var new_bitmap_path = GetCompleteFolder(GetFolderName(safeFileName));

            for (var x = 0; x < tile_count_x; x++) {
                for (var y = 0; y < tile_count_y; y++) {
                    new_bitmap = CreateTileFromImage(ref bitmap, x, y);

                    if (RadioGround.Checked) {
                        Map.Ground[count].Name = $"{safeFileName}_ground_{count + 1}";
                        Map.Ground[count].Bitmap = new_bitmap;

                        new_bitmap.Save(new_bitmap_path + $@"\{safeFileName}_ground_{count + 1}.png");
                    }
                    else if (RadioFringe.Checked) {
                        Map.Fringe[count].Name = $"{safeFileName}_fringe_{count + 1}";
                        Map.Fringe[count].Bitmap = new_bitmap;

                        new_bitmap.Save(new_bitmap_path + $@"\{safeFileName}_fringe_{count + 1}.png");
                    }

                    count++;
                }
            }

            PictureMap.Invalidate();
        }

        private Bitmap CreateTileFromImage(ref Bitmap bitmap, int source_x, int source_y) {
            var destination = new Rectangle() {
                X = 0,
                Y = 0,
                Width = TileSize,
                Height = TileSize
            };

            var source = new Rectangle() {
                X = source_x * TileSize,
                Y = source_y * TileSize,
                Width = TileSize,
                Height = TileSize
            };

            var new_tile = new Bitmap(TileSize, TileSize);

            var g = Graphics.FromImage(new_tile);
            g.Clear(Color.Transparent);

            g.DrawImage(bitmap, destination, source, GraphicsUnit.Pixel);
            g.Dispose();

            return new_tile;
        }

        private void ShowInvalidImage() {
            string text = "Invalid image size." + Environment.NewLine + "Size must be or more than 32x32.";
            MessageBox.Show(text);
        }

        #endregion

        #region Create Map Folder From Image

        private void CreateMapFolderFromImage(string fileName, string safeFileName) {
            var bitmap = new Bitmap(fileName);

            var tile_count_x = bitmap.Width / TileSize;
            var tile_count_y = bitmap.Height / TileSize;

            if (bitmap.Width % TileSize > 0) {
                tile_count_x++;
            }

            if (bitmap.Height % TileSize > 0) {
                tile_count_y++;
            }

            var count = 0;
            Bitmap new_bitmap;

            CreateMapFolder(GetCompleteFolder(GetFolderName(safeFileName)));
            var new_bitmap_path = GetCompleteFolder(GetFolderName(safeFileName));

            for (var x = 0; x < tile_count_x; x++) {
                for (var y = 0; y < tile_count_y; y++) {
                    new_bitmap = CreateTileFromImage(ref bitmap, x, y);

                    if (RadioGround.Checked) {
                        new_bitmap.Save(new_bitmap_path + $@"\{safeFileName}_ground_{count + 1}.png");
                    }
                    else if (RadioFringe.Checked) {
                        new_bitmap.Save(new_bitmap_path + $@"\{safeFileName}_fringe_{count + 1}.png");
                    }

                    count++;
                }
            }

            MessageBox.Show("Saved");
        }

        private string GetCompleteFolder(string folder) {
            var result = Environment.CurrentDirectory + @"\";

            if (RadioGround.Checked) {
                result += folder + @"\Ground";
            }
            else if (RadioFringe.Checked) {
                result += folder + @"\Fringe";
            }

            return result;
        }

        private string GetFolderName(string safeFileName) {
            var name = safeFileName.Split('.');
            return name[0];
        }

        private void CreateMapFolder(string folderName) {
            if (!Directory.Exists(folderName)) {
                Directory.CreateDirectory(folderName);
            }
        }

        #endregion

        #region Export

        private void MenuExportTypeA_Click(object sender, EventArgs e) {

        }

        private void MenuExportTypeB_Click(object sender, EventArgs e) {
            if (panel.IsDisposed) {
                panel = new ExportPanel();
            }

            panel.Show(Map);
        }

        #endregion

        #region Opacity

        private void ScrollGridOpacity_Scroll(object sender, ScrollEventArgs e) {
            var value = ScrollGridOpacity.Value;

            LabelGridOpacity.Text = "Grid Map: " + value;

            var white_brush = new SolidBrush(Color.FromArgb(value, Color.LightGray));
            white_pen = new Pen(white_brush, 1);

            PictureMap.Invalidate();
        }

        private void ScrollParallaxOpacity_Scroll(object sender, ScrollEventArgs e) {
            var value = ScrollParallaxOpacity.Value;

            LabelParallaxOpacity.Text = "Grid Parallax: " + value;

            var coral_brush = new SolidBrush(Color.FromArgb(value, Color.Coral));
            coral_pen = new Pen(coral_brush, 3);

            PictureMap.Invalidate();
        }

        #endregion

    }
}