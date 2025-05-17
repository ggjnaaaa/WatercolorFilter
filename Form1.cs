using KR.Models;
using KR.Services;

namespace KR
{
    public partial class Form1 : Form
    {
        private ImageEditor _imageEditor;
        private Dictionary<string, Bitmap> _masks;
        private bool _isComboboxSelected = false;

        public Form1()
        {
            InitializeComponent();
            InitializeSliders();

            _masks = new Dictionary<string, Bitmap>();
            InitializeMaskComboBox();
        }

        /// <summary>
        /// Загрузка изображения при нажатии на кнопку загрузки.
        /// </summary>
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            var img = ImageLoader.LoadImage();
            if (img == null)
            {
                MessageBox.Show("Ошибка загрузки изображения.");
                return;
            }
            _imageEditor = new ImageEditor(img, initBrightnessValue * 10, initContrastValue / 10);
            var currentImage = _imageEditor.GetImage();
            if (currentImage != null)
            {
                imageBoxOriginal.Image = currentImage;
                imageBoxResult.Image = currentImage;
            }

            resetBrightnessAndContrastSlider();
        }

        private void InitializeMaskComboBox()
        {
            List<Bitmap> masks = ImageLoader.LoadMaskBitmapsFromFormResources();

            for (int i = 0; i < masks.Count; i++)
            {
                var name = $"Маска {i + 1}";
                var image = masks[i];

                _masks.Add(name, image);

                comboBox1.Items.Add(name);
            }

            if (comboBox1.Items.Count > 0)
            {
                _isComboboxSelected = true;
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isComboboxSelected)
            {
                _isComboboxSelected = false;
                return;
            }
            string selectedKey = comboBox1.SelectedItem as string;
            if (selectedKey != null && _masks.TryGetValue(selectedKey, out Bitmap maskBmp))
            {
                _imageEditor.ApplyMask(maskBmp);

                var processed = _imageEditor.GetImage(true);
                imageBoxResult.Image = processed;
            }
        }
    }
}
