namespace MapEditor {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGroundView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFringeView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGridView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGridViewTile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGridViewParallax = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuParallax = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuParallaxId = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuParallaxName = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImagem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCreateMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportToClient = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportTypeA = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportTypeB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelParallaxOpacity = new System.Windows.Forms.Label();
            this.ScrollParallaxOpacity = new System.Windows.Forms.HScrollBar();
            this.LabelGridOpacity = new System.Windows.Forms.Label();
            this.ScrollGridOpacity = new System.Windows.Forms.HScrollBar();
            this.GroupRegion = new System.Windows.Forms.GroupBox();
            this.ButtonClearDirection = new System.Windows.Forms.Button();
            this.RadioDirection = new System.Windows.Forms.RadioButton();
            this.RadioAttributes = new System.Windows.Forms.RadioButton();
            this.RadioFringe = new System.Windows.Forms.RadioButton();
            this.RadioGround = new System.Windows.Forms.RadioButton();
            this.GroupAttributes = new System.Windows.Forms.GroupBox();
            this.ButtonClearAttribute = new System.Windows.Forms.Button();
            this.RadioWarp = new System.Windows.Forms.RadioButton();
            this.RadioChat = new System.Windows.Forms.RadioButton();
            this.RadioTrap = new System.Windows.Forms.RadioButton();
            this.RadioAvoid = new System.Windows.Forms.RadioButton();
            this.RadioBlock = new System.Windows.Forms.RadioButton();
            this.PictureMap = new System.Windows.Forms.PictureBox();
            this.ScrollStartY = new System.Windows.Forms.HScrollBar();
            this.ScrollStartX = new System.Windows.Forms.HScrollBar();
            this.LabelY = new System.Windows.Forms.Label();
            this.LabelX = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupRegion.SuspendLayout();
            this.GroupAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuView,
            this.MenuImagem,
            this.MenuExport,
            this.MenuProperty});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.MenuSaveAs,
            this.MenuExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(114, 22);
            this.MenuOpen.Text = "Open";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(114, 22);
            this.MenuSave.Text = "Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuSaveAs
            // 
            this.MenuSaveAs.Name = "MenuSaveAs";
            this.MenuSaveAs.Size = new System.Drawing.Size(114, 22);
            this.MenuSaveAs.Text = "Save As";
            this.MenuSaveAs.Click += new System.EventHandler(this.MenuSaveAs_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(114, 22);
            this.MenuExit.Text = "Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MenuView
            // 
            this.MenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGroundView,
            this.MenuFringeView,
            this.MenuGridView,
            this.MenuParallax});
            this.MenuView.Name = "MenuView";
            this.MenuView.Size = new System.Drawing.Size(44, 20);
            this.MenuView.Text = "View";
            // 
            // MenuGroundView
            // 
            this.MenuGroundView.Checked = true;
            this.MenuGroundView.CheckOnClick = true;
            this.MenuGroundView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuGroundView.Name = "MenuGroundView";
            this.MenuGroundView.Size = new System.Drawing.Size(115, 22);
            this.MenuGroundView.Text = "Ground";
            this.MenuGroundView.Click += new System.EventHandler(this.MenuGroundView_Click);
            // 
            // MenuFringeView
            // 
            this.MenuFringeView.Checked = true;
            this.MenuFringeView.CheckOnClick = true;
            this.MenuFringeView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuFringeView.Name = "MenuFringeView";
            this.MenuFringeView.Size = new System.Drawing.Size(115, 22);
            this.MenuFringeView.Text = "Fringe";
            this.MenuFringeView.Click += new System.EventHandler(this.MenuFringeView_Click);
            // 
            // MenuGridView
            // 
            this.MenuGridView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGridViewTile,
            this.MenuGridViewParallax});
            this.MenuGridView.Name = "MenuGridView";
            this.MenuGridView.Size = new System.Drawing.Size(115, 22);
            this.MenuGridView.Text = "Grid";
            // 
            // MenuGridViewTile
            // 
            this.MenuGridViewTile.Checked = true;
            this.MenuGridViewTile.CheckOnClick = true;
            this.MenuGridViewTile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuGridViewTile.Name = "MenuGridViewTile";
            this.MenuGridViewTile.Size = new System.Drawing.Size(115, 22);
            this.MenuGridViewTile.Text = "Tile";
            this.MenuGridViewTile.Click += new System.EventHandler(this.MenuGridViewTile_Click);
            // 
            // MenuGridViewParallax
            // 
            this.MenuGridViewParallax.Checked = true;
            this.MenuGridViewParallax.CheckOnClick = true;
            this.MenuGridViewParallax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuGridViewParallax.Name = "MenuGridViewParallax";
            this.MenuGridViewParallax.Size = new System.Drawing.Size(115, 22);
            this.MenuGridViewParallax.Text = "Parallax";
            this.MenuGridViewParallax.Click += new System.EventHandler(this.MenuGridViewParallax_Click);
            // 
            // MenuParallax
            // 
            this.MenuParallax.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuParallaxId,
            this.MenuParallaxName});
            this.MenuParallax.Name = "MenuParallax";
            this.MenuParallax.Size = new System.Drawing.Size(115, 22);
            this.MenuParallax.Text = "Parallax";
            // 
            // MenuParallaxId
            // 
            this.MenuParallaxId.Checked = true;
            this.MenuParallaxId.CheckOnClick = true;
            this.MenuParallaxId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuParallaxId.Name = "MenuParallaxId";
            this.MenuParallaxId.Size = new System.Drawing.Size(105, 22);
            this.MenuParallaxId.Text = "Id";
            this.MenuParallaxId.Click += new System.EventHandler(this.MenuParallaxId_Click);
            // 
            // MenuParallaxName
            // 
            this.MenuParallaxName.Checked = true;
            this.MenuParallaxName.CheckOnClick = true;
            this.MenuParallaxName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuParallaxName.Name = "MenuParallaxName";
            this.MenuParallaxName.Size = new System.Drawing.Size(105, 22);
            this.MenuParallaxName.Text = "Name";
            this.MenuParallaxName.Click += new System.EventHandler(this.MenuParallaxName_Click);
            // 
            // MenuImagem
            // 
            this.MenuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCreateMap,
            this.MenuCreateFolder});
            this.MenuImagem.Name = "MenuImagem";
            this.MenuImagem.Size = new System.Drawing.Size(51, 20);
            this.MenuImagem.Text = "Image";
            // 
            // MenuCreateMap
            // 
            this.MenuCreateMap.Name = "MenuCreateMap";
            this.MenuCreateMap.Size = new System.Drawing.Size(205, 22);
            this.MenuCreateMap.Text = "Create Map From Image";
            this.MenuCreateMap.Click += new System.EventHandler(this.MenuCreateMap_Click);
            // 
            // MenuCreateFolder
            // 
            this.MenuCreateFolder.Name = "MenuCreateFolder";
            this.MenuCreateFolder.Size = new System.Drawing.Size(205, 22);
            this.MenuCreateFolder.Text = "Create Image Map Folder";
            this.MenuCreateFolder.Click += new System.EventHandler(this.MenuCreateFolder_Click);
            // 
            // MenuExport
            // 
            this.MenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportToClient});
            this.MenuExport.Name = "MenuExport";
            this.MenuExport.Size = new System.Drawing.Size(53, 20);
            this.MenuExport.Text = "Export";
            // 
            // MenuExportToClient
            // 
            this.MenuExportToClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportTypeA,
            this.MenuExportTypeB});
            this.MenuExportToClient.Name = "MenuExportToClient";
            this.MenuExportToClient.Size = new System.Drawing.Size(180, 22);
            this.MenuExportToClient.Text = "To Client";
            // 
            // MenuExportTypeA
            // 
            this.MenuExportTypeA.Enabled = false;
            this.MenuExportTypeA.Name = "MenuExportTypeA";
            this.MenuExportTypeA.Size = new System.Drawing.Size(180, 22);
            this.MenuExportTypeA.Text = "Type A";
            this.MenuExportTypeA.ToolTipText = "Cada imagem parallax é salvada separadamente.";
            this.MenuExportTypeA.Click += new System.EventHandler(this.MenuExportTypeA_Click);
            // 
            // MenuExportTypeB
            // 
            this.MenuExportTypeB.Name = "MenuExportTypeB";
            this.MenuExportTypeB.Size = new System.Drawing.Size(180, 22);
            this.MenuExportTypeB.Text = "Type B";
            this.MenuExportTypeB.ToolTipText = "Todos as imagens parallax são salvadas em um único arquivo.";
            this.MenuExportTypeB.Click += new System.EventHandler(this.MenuExportTypeB_Click);
            // 
            // MenuProperty
            // 
            this.MenuProperty.Name = "MenuProperty";
            this.MenuProperty.Size = new System.Drawing.Size(64, 20);
            this.MenuProperty.Text = "Property";
            this.MenuProperty.Click += new System.EventHandler(this.MenuProperty_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.GroupRegion);
            this.groupBox1.Controls.Add(this.GroupAttributes);
            this.groupBox1.Controls.Add(this.PictureMap);
            this.groupBox1.Controls.Add(this.ScrollStartY);
            this.groupBox1.Controls.Add(this.ScrollStartX);
            this.groupBox1.Controls.Add(this.LabelY);
            this.groupBox1.Controls.Add(this.LabelX);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 593);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LabelParallaxOpacity);
            this.groupBox2.Controls.Add(this.ScrollParallaxOpacity);
            this.groupBox2.Controls.Add(this.LabelGridOpacity);
            this.groupBox2.Controls.Add(this.ScrollGridOpacity);
            this.groupBox2.Location = new System.Drawing.Point(794, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 191);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grid Opacity";
            // 
            // LabelParallaxOpacity
            // 
            this.LabelParallaxOpacity.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelParallaxOpacity.Location = new System.Drawing.Point(14, 73);
            this.LabelParallaxOpacity.Name = "LabelParallaxOpacity";
            this.LabelParallaxOpacity.Size = new System.Drawing.Size(155, 17);
            this.LabelParallaxOpacity.TabIndex = 9;
            this.LabelParallaxOpacity.Text = "Grid Parallax: 255";
            this.LabelParallaxOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScrollParallaxOpacity
            // 
            this.ScrollParallaxOpacity.LargeChange = 1;
            this.ScrollParallaxOpacity.Location = new System.Drawing.Point(17, 90);
            this.ScrollParallaxOpacity.Maximum = 255;
            this.ScrollParallaxOpacity.Name = "ScrollParallaxOpacity";
            this.ScrollParallaxOpacity.Size = new System.Drawing.Size(139, 17);
            this.ScrollParallaxOpacity.TabIndex = 8;
            this.ScrollParallaxOpacity.Value = 255;
            this.ScrollParallaxOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollParallaxOpacity_Scroll);
            // 
            // LabelGridOpacity
            // 
            this.LabelGridOpacity.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGridOpacity.Location = new System.Drawing.Point(14, 26);
            this.LabelGridOpacity.Name = "LabelGridOpacity";
            this.LabelGridOpacity.Size = new System.Drawing.Size(119, 17);
            this.LabelGridOpacity.TabIndex = 7;
            this.LabelGridOpacity.Text = "Grid Map: 255";
            this.LabelGridOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScrollGridOpacity
            // 
            this.ScrollGridOpacity.LargeChange = 1;
            this.ScrollGridOpacity.Location = new System.Drawing.Point(17, 43);
            this.ScrollGridOpacity.Maximum = 255;
            this.ScrollGridOpacity.Name = "ScrollGridOpacity";
            this.ScrollGridOpacity.Size = new System.Drawing.Size(139, 17);
            this.ScrollGridOpacity.TabIndex = 6;
            this.ScrollGridOpacity.Value = 255;
            this.ScrollGridOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollGridOpacity_Scroll);
            // 
            // GroupRegion
            // 
            this.GroupRegion.Controls.Add(this.ButtonClearDirection);
            this.GroupRegion.Controls.Add(this.RadioDirection);
            this.GroupRegion.Controls.Add(this.RadioAttributes);
            this.GroupRegion.Controls.Add(this.RadioFringe);
            this.GroupRegion.Controls.Add(this.RadioGround);
            this.GroupRegion.Location = new System.Drawing.Point(794, 17);
            this.GroupRegion.Name = "GroupRegion";
            this.GroupRegion.Size = new System.Drawing.Size(175, 167);
            this.GroupRegion.TabIndex = 9;
            this.GroupRegion.TabStop = false;
            this.GroupRegion.Text = "Area";
            // 
            // ButtonClearDirection
            // 
            this.ButtonClearDirection.Enabled = false;
            this.ButtonClearDirection.Location = new System.Drawing.Point(17, 123);
            this.ButtonClearDirection.Name = "ButtonClearDirection";
            this.ButtonClearDirection.Size = new System.Drawing.Size(139, 23);
            this.ButtonClearDirection.TabIndex = 11;
            this.ButtonClearDirection.Text = "Clear Directions";
            this.ButtonClearDirection.UseVisualStyleBackColor = true;
            this.ButtonClearDirection.Click += new System.EventHandler(this.ButtonClearDirection_Click);
            // 
            // RadioDirection
            // 
            this.RadioDirection.Location = new System.Drawing.Point(17, 88);
            this.RadioDirection.Name = "RadioDirection";
            this.RadioDirection.Size = new System.Drawing.Size(109, 19);
            this.RadioDirection.TabIndex = 3;
            this.RadioDirection.TabStop = true;
            this.RadioDirection.Text = "Direction";
            this.RadioDirection.UseVisualStyleBackColor = true;
            this.RadioDirection.CheckedChanged += new System.EventHandler(this.RadioDirection_CheckedChanged);
            // 
            // RadioAttributes
            // 
            this.RadioAttributes.Location = new System.Drawing.Point(17, 65);
            this.RadioAttributes.Name = "RadioAttributes";
            this.RadioAttributes.Size = new System.Drawing.Size(109, 19);
            this.RadioAttributes.TabIndex = 2;
            this.RadioAttributes.TabStop = true;
            this.RadioAttributes.Text = "Attributes";
            this.RadioAttributes.UseVisualStyleBackColor = true;
            this.RadioAttributes.CheckedChanged += new System.EventHandler(this.RadioAttributes_CheckedChanged);
            // 
            // RadioFringe
            // 
            this.RadioFringe.Location = new System.Drawing.Point(17, 42);
            this.RadioFringe.Name = "RadioFringe";
            this.RadioFringe.Size = new System.Drawing.Size(109, 19);
            this.RadioFringe.TabIndex = 1;
            this.RadioFringe.TabStop = true;
            this.RadioFringe.Text = "Fringe";
            this.RadioFringe.UseVisualStyleBackColor = true;
            this.RadioFringe.CheckedChanged += new System.EventHandler(this.RadioFringe_CheckedChanged);
            // 
            // RadioGround
            // 
            this.RadioGround.Checked = true;
            this.RadioGround.Location = new System.Drawing.Point(17, 20);
            this.RadioGround.Name = "RadioGround";
            this.RadioGround.Size = new System.Drawing.Size(109, 16);
            this.RadioGround.TabIndex = 0;
            this.RadioGround.TabStop = true;
            this.RadioGround.Text = "Ground";
            this.RadioGround.UseVisualStyleBackColor = true;
            this.RadioGround.CheckedChanged += new System.EventHandler(this.RadioGround_CheckedChanged);
            // 
            // GroupAttributes
            // 
            this.GroupAttributes.Controls.Add(this.ButtonClearAttribute);
            this.GroupAttributes.Controls.Add(this.RadioWarp);
            this.GroupAttributes.Controls.Add(this.RadioChat);
            this.GroupAttributes.Controls.Add(this.RadioTrap);
            this.GroupAttributes.Controls.Add(this.RadioAvoid);
            this.GroupAttributes.Controls.Add(this.RadioBlock);
            this.GroupAttributes.Enabled = false;
            this.GroupAttributes.Location = new System.Drawing.Point(794, 190);
            this.GroupAttributes.Name = "GroupAttributes";
            this.GroupAttributes.Size = new System.Drawing.Size(175, 191);
            this.GroupAttributes.TabIndex = 8;
            this.GroupAttributes.TabStop = false;
            this.GroupAttributes.Text = "Attributes";
            // 
            // ButtonClearAttribute
            // 
            this.ButtonClearAttribute.Location = new System.Drawing.Point(17, 160);
            this.ButtonClearAttribute.Name = "ButtonClearAttribute";
            this.ButtonClearAttribute.Size = new System.Drawing.Size(139, 23);
            this.ButtonClearAttribute.TabIndex = 10;
            this.ButtonClearAttribute.Text = "Clear Attributes";
            this.ButtonClearAttribute.UseVisualStyleBackColor = true;
            this.ButtonClearAttribute.Click += new System.EventHandler(this.ButtonClearAttribute_Click);
            // 
            // RadioWarp
            // 
            this.RadioWarp.Location = new System.Drawing.Point(17, 121);
            this.RadioWarp.Name = "RadioWarp";
            this.RadioWarp.Size = new System.Drawing.Size(109, 19);
            this.RadioWarp.TabIndex = 9;
            this.RadioWarp.Text = "Warp";
            this.RadioWarp.UseVisualStyleBackColor = true;
            // 
            // RadioChat
            // 
            this.RadioChat.Location = new System.Drawing.Point(17, 96);
            this.RadioChat.Name = "RadioChat";
            this.RadioChat.Size = new System.Drawing.Size(109, 19);
            this.RadioChat.TabIndex = 8;
            this.RadioChat.Text = "Chat";
            this.RadioChat.UseVisualStyleBackColor = true;
            // 
            // RadioTrap
            // 
            this.RadioTrap.Location = new System.Drawing.Point(17, 70);
            this.RadioTrap.Name = "RadioTrap";
            this.RadioTrap.Size = new System.Drawing.Size(109, 19);
            this.RadioTrap.TabIndex = 6;
            this.RadioTrap.Text = "Trap";
            this.RadioTrap.UseVisualStyleBackColor = true;
            // 
            // RadioAvoid
            // 
            this.RadioAvoid.Location = new System.Drawing.Point(17, 45);
            this.RadioAvoid.Name = "RadioAvoid";
            this.RadioAvoid.Size = new System.Drawing.Size(109, 19);
            this.RadioAvoid.TabIndex = 5;
            this.RadioAvoid.Text = "Npc Avoid";
            this.RadioAvoid.UseVisualStyleBackColor = true;
            // 
            // RadioBlock
            // 
            this.RadioBlock.Checked = true;
            this.RadioBlock.Location = new System.Drawing.Point(17, 20);
            this.RadioBlock.Name = "RadioBlock";
            this.RadioBlock.Size = new System.Drawing.Size(109, 19);
            this.RadioBlock.TabIndex = 4;
            this.RadioBlock.TabStop = true;
            this.RadioBlock.Text = "Block";
            this.RadioBlock.UseVisualStyleBackColor = true;
            // 
            // PictureMap
            // 
            this.PictureMap.BackColor = System.Drawing.Color.Black;
            this.PictureMap.Location = new System.Drawing.Point(12, 65);
            this.PictureMap.Name = "PictureMap";
            this.PictureMap.Size = new System.Drawing.Size(768, 512);
            this.PictureMap.TabIndex = 7;
            this.PictureMap.TabStop = false;
            this.PictureMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureMap_Paint);
            this.PictureMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureMap_MouseDown);
            // 
            // ScrollStartY
            // 
            this.ScrollStartY.LargeChange = 1;
            this.ScrollStartY.Location = new System.Drawing.Point(62, 39);
            this.ScrollStartY.Maximum = 0;
            this.ScrollStartY.Name = "ScrollStartY";
            this.ScrollStartY.Size = new System.Drawing.Size(718, 17);
            this.ScrollStartY.TabIndex = 6;
            this.ScrollStartY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollStartY_Scroll);
            // 
            // ScrollStartX
            // 
            this.ScrollStartX.LargeChange = 1;
            this.ScrollStartX.Location = new System.Drawing.Point(62, 17);
            this.ScrollStartX.Maximum = 0;
            this.ScrollStartX.Name = "ScrollStartX";
            this.ScrollStartX.Size = new System.Drawing.Size(718, 17);
            this.ScrollStartX.TabIndex = 5;
            this.ScrollStartX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollStartX_Scroll);
            // 
            // LabelY
            // 
            this.LabelY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelY.Location = new System.Drawing.Point(9, 39);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(50, 17);
            this.LabelY.TabIndex = 4;
            this.LabelY.Text = "Y: 0";
            this.LabelY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelX
            // 
            this.LabelX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX.Location = new System.Drawing.Point(10, 17);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(49, 17);
            this.LabelX.TabIndex = 3;
            this.LabelX.Text = "X: 0";
            this.LabelX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 632);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor - NoTitle.mps";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.GroupRegion.ResumeLayout(false);
            this.GroupAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuProperty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelY;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.HScrollBar ScrollStartY;
        private System.Windows.Forms.HScrollBar ScrollStartX;
        private System.Windows.Forms.PictureBox PictureMap;
        private System.Windows.Forms.GroupBox GroupAttributes;
        private System.Windows.Forms.GroupBox GroupRegion;
        private System.Windows.Forms.RadioButton RadioFringe;
        private System.Windows.Forms.RadioButton RadioGround;
        private System.Windows.Forms.RadioButton RadioAttributes;
        private System.Windows.Forms.ToolStripMenuItem MenuView;
        private System.Windows.Forms.ToolStripMenuItem MenuGroundView;
        private System.Windows.Forms.ToolStripMenuItem MenuFringeView;
        private System.Windows.Forms.ToolStripMenuItem MenuGridView;
        private System.Windows.Forms.ToolStripMenuItem MenuGridViewTile;
        private System.Windows.Forms.ToolStripMenuItem MenuGridViewParallax;
        private System.Windows.Forms.RadioButton RadioDirection;
        private System.Windows.Forms.ToolStripMenuItem MenuParallax;
        private System.Windows.Forms.ToolStripMenuItem MenuParallaxId;
        private System.Windows.Forms.ToolStripMenuItem MenuParallaxName;
        private System.Windows.Forms.RadioButton RadioAvoid;
        private System.Windows.Forms.RadioButton RadioBlock;
        private System.Windows.Forms.RadioButton RadioTrap;
        private System.Windows.Forms.RadioButton RadioChat;
        private System.Windows.Forms.RadioButton RadioWarp;
        private System.Windows.Forms.Button ButtonClearAttribute;
        private System.Windows.Forms.Button ButtonClearDirection;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
        private System.Windows.Forms.ToolStripMenuItem MenuImagem;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateMap;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuExportToClient;
        private System.Windows.Forms.ToolStripMenuItem MenuExportTypeA;
        private System.Windows.Forms.ToolStripMenuItem MenuExportTypeB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar ScrollGridOpacity;
        private System.Windows.Forms.Label LabelGridOpacity;
        private System.Windows.Forms.Label LabelParallaxOpacity;
        private System.Windows.Forms.HScrollBar ScrollParallaxOpacity;
    }
}

