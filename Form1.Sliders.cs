namespace KR
{
    public partial class Form1
    {
        // Начальные значения для яркости и контраста
        private int initBrightnessValue;
        private int initContrastValue;


        /// <summary>
        /// Инициализирует ползунки для яркости и контраста.
        /// </summary>
        private void InitializeSliders()
        {
            // Устанавливаем начальные значения для яркости и контраста
            initBrightnessValue = brightnessSlider.Minimum;
            initContrastValue = contrastSlider.Maximum / 2;

            // Устанавливаем начальные значения на ползунках
            brightnessSlider.Value = initBrightnessValue;
            contrastSlider.Value = initContrastValue;
        }


        // Обработчик изменения положения ползунка яркости.
        private void brightnessSlider_Scroll(object sender, EventArgs e)
        {
            if (_imageEditor == null)
                return;

            // Применяем изменения яркости
            _imageEditor.AdjustBrightness(brightnessSlider.Value * 10);
            imageBoxResult.Image = _imageEditor.GetImage(true);
        }

        // Обработчик изменения положения ползунка контраста.
        private void contrastSlider_Scroll(object sender, EventArgs e)
        {
            if (_imageEditor == null)
                return;

            // Нормализуем значение контраста относительно его диапазона
            double temp = (Math.Abs(contrastSlider.Maximum) + Math.Abs(contrastSlider.Minimum)) / 2.0;
            _imageEditor.AdjustContrast(contrastSlider.Value / temp);
            imageBoxResult.Image = _imageEditor.GetImage(true);
        }

        // Обработчик для изменения радиуса размытия (ползунок).
        private void radiusBlur_Scroll(object sender, EventArgs e)
        {
            _imageEditor.ApplyMedianBlur(Convert.ToInt32(radiusBlur.Value));

            imageBoxResult.Image = _imageEditor.GetImage(true).Copy();
        }

        /// <summary>
        /// Сбрасывает ползунок яркости на начальное значение.
        /// </summary>
        private void resetBrightnessSlider()
        {
            brightnessSlider.Value = initBrightnessValue;
        }

        /// <summary>
        /// Сбрасывает ползунок контраста на начальное значение.
        /// </summary>
        private void resetContrastSlider()
        {
            contrastSlider.Value = initContrastValue;
        }

        /// <summary>
        /// Сбрасывает оба ползунка — яркость и контраст.
        /// </summary>
        private void resetBrightnessAndContrastSlider()
        {
            resetBrightnessSlider();
            resetContrastSlider();
        }
    }
}
