using System;
using System.Windows.Forms;

namespace MapEditor {
    public partial class Property : Form {

        MapProperty property { get; set; }

        Main main_form;

        public Property() {
            InitializeComponent();

            var names = Enum.GetNames(typeof(Moral));

            for (var i = 0; i < names.Length; i++) {
                ComboMoral.Items.Add(names[i]);
            }

            names = Enum.GetNames(typeof(Blending));

            for (var i = 0; i < names.Length; i++) {
                ComboBlending.Items.Add(names[i]);
            }

            names = Enum.GetNames(typeof(Weather));

            for (var i = 0; i < names.Length; i++) {
                ComboWeather.Items.Add(names[i]);
            }

            ComboMoral.SelectedIndex = 0;
            ComboBlending.SelectedIndex = 0;
            ComboWeather.SelectedIndex = 0;
        }

        public void Show(Main caller, MapProperty mapProperty) {
            property = mapProperty;
            main_form = caller;

            if (property != null) {
                UpdateProperties();
            }

            Show();
        }

        private int GetInt32Value(ref TextBox from) {
            var result = int.TryParse(from.Text, out int value);

            if (result) {
                return value;
            }

            return 0;
        }

        private void UpdateProperties() {
            TextName.Text = property.Name;

            TextUp.Text = property.Link.Up.ToString();
            TextLeft.Text = property.Link.Left.ToString();
            TextRight.Text = property.Link.Right.ToString();
            TextDown.Text = property.Link.Down.ToString();

            ComboWeather.SelectedIndex = (int)property.Weather;
            ComboMoral.SelectedIndex = (int)property.Moral;

            TextMapId.Text = property.Boot.Id.ToString();
            TextX.Text = property.Boot.X.ToString();
            TextY.Text = property.Boot.Y.ToString();

            TextMusic.Text = property.Music;
            TextAmbience.Text = property.Ambience;

            TextWidth.Text = (property.Width - 1).ToString();
            TextHeight.Text = (property.Height - 1).ToString();

            TextFogId.Text = property.Fog.Id.ToString();
            ComboBlending.SelectedIndex = (int)property.Fog.Blending;

            LabelOpacity.Text = $"Opacity: {property.Fog.Opacity}";
            ScrollOpacity.Value = property.Fog.Opacity;

            LabelRed.Text = $"Red: {property.Fog.Red}";
            ScrollRed.Value = property.Fog.Red;

            LabelGreen.Text = $"Green: {property.Fog.Green}";
            ScrollGreen.Value = property.Fog.Green;

            LabelBlue.Text = $"Blue: {property.Fog.Blue}";
            ScrollBlue.Value = property.Fog.Blue;

            TextKeyA.Text = property.KeyA;
            TextKeyB.Text = property.KeyB;
            TextKeyC.Text = property.KeyC;
        }

        #region Name
        private void TextName_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.Name = TextName.Text.Trim();
            }
        }

        #endregion

        #region Music
        private void TextMusic_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.Music = TextMusic.Text.Trim();
            }
        }

        private void TextAmbience_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.Ambience = TextAmbience.Text.Trim();
            }
        }
        #endregion

        #region Link

        private void TextUp_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var link = property.Link;

                link.Up = GetInt32Value(ref TextUp);

                property.Link = link;           
            }
        }

        private void TextLeft_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var link = property.Link;

                link.Left = GetInt32Value(ref TextLeft);

                property.Link = link;
            }
        }

        private void TextRight_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var link = property.Link;

                link.Right = GetInt32Value(ref TextRight);

                property.Link = link;
            }
        }

        private void TextDown_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var link = property.Link;

                link.Down = GetInt32Value(ref TextDown);

                property.Link = link;
            }
        }

        #endregion

        #region Weather

        private void ComboWeather_SelectedIndexChanged(object sender, EventArgs e) {
            if (property != null) {
                var weather = (Weather)ComboWeather.SelectedIndex;
                property.Weather = weather;
            }
        }

        #endregion

        #region Moral
        
        private void ComboMoral_SelectedIndexChanged(object sender, EventArgs e) {
            if (property != null) {
                var moral = (Moral)ComboMoral.SelectedIndex;
                property.Moral = moral;
            }
        }

        #endregion

        #region Boot

        private void TextMapId_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var boot = property.Boot;

                boot.Id = GetInt32Value(ref TextMapId);

                property.Boot = boot;
            }
        }

        private void TextY_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var boot = property.Boot;

                boot.Y = GetInt32Value(ref TextY);

                property.Boot = boot;
            }
        }

        private void TextX_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var boot = property.Boot;

                boot.X = GetInt32Value(ref TextX);

                property.Boot = boot;
            }
        }


        #endregion

        #region Fog

        private void TextFogId_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Id = GetInt32Value(ref TextUp);

                property.Fog = fog;
            }
        }

        private void ComboBlending_SelectedIndexChanged(object sender, EventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Blending = (Blending)ComboBlending.SelectedIndex;

                property.Fog = fog;
            }
        }

        private void ScrollOpacity_Scroll(object sender, ScrollEventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Opacity = Convert.ToByte(ScrollOpacity.Value);

                property.Fog = fog;

                LabelOpacity.Text = $"Opacity: {property.Fog.Opacity}";
            }
        }

        private void ScrollRed_Scroll(object sender, ScrollEventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Red  = Convert.ToByte(ScrollRed.Value);

                property.Fog = fog;

                LabelRed.Text = $"Red: {property.Fog.Red}";
            }
        }

        private void ScrollGreen_Scroll(object sender, ScrollEventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Green = Convert.ToByte(ScrollGreen.Value);

                property.Fog = fog;

                LabelGreen.Text = $"Green: {property.Fog.Green}";
            }
        }

        private void ScrollBlue_Scroll(object sender, ScrollEventArgs e) {
            if (property != null) {
                var fog = property.Fog;

                fog.Blue = Convert.ToByte(ScrollBlue.Value);

                property.Fog = fog;

                LabelBlue.Text = $"Blue: {property.Fog.Blue}";
            }
        }

        #endregion

        #region Size

        private void TextWidth_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var value = GetInt32Value(ref TextWidth);

                if (value == 0) {
                    value = 1;
                }

                property.Width = value + 1;
            }
        }

        private void TextHeight_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                var value = GetInt32Value(ref TextHeight);

                if (value == 0) {
                    value = 1;
                }

                property.Height = value + 1;
            }
        }

        private void TextWidth_Validated(object sender, EventArgs e) {
            if (property != null) {
                main_form.UpdateSize();
            }
        }

        private void TextHeight_Validated(object sender, EventArgs e) {
            if (property != null) {
                main_form.UpdateSize();
            }
        }

        #endregion

        #region Passwords
        private void TextKeyA_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.KeyA = TextKeyA.Text.Trim();
            }
        }

        private void TextKeyB_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.KeyB = TextKeyB.Text.Trim();
            }
        }

        private void TextKeyC_TextChanged(object sender, EventArgs e) {
            if (property != null) {
                property.KeyC = TextKeyC.Text.Trim();
            }
        }

        #endregion

    }
}