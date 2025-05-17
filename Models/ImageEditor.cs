using Emgu.CV.Structure;
using Emgu.CV;
using KR.Services;

namespace KR.Models
{
    internal class ImageEditor
    {
        private Image<Bgr, byte> _originalImage;
        private Image<Bgr, byte> _currentImage;

        private List<Action<Image<Bgr, byte>>> _filters;    // Список применённых фильтров
        private Action<Image<Bgr, byte>> _medianBlurFilter; // Фильтр медианного размытия
        private Action<Image<Bgr, byte>> _maskFilter; // Маска

        private Bitmap _maskBitmap; // Маска в виде Bitmap

        public readonly int initBrightness;     // Начальное значение яркости
        public readonly double initContrast;    // Начальное значение контраста

        public int currentBrightness { get; private set; }      // Текущая яркость
        public double currentContrast { get; private set; }     // Текущий контраст


        // Конструктор с оригинальным изображением
        public ImageEditor(Image<Bgr, byte> originalImage, int initBrightness, double initContrast)
        {
            _originalImage = originalImage.Copy();
            _currentImage = _originalImage.Copy();
            _filters = new List<Action<Image<Bgr, byte>>>();

            this.initBrightness = initBrightness;
            this.initContrast = initContrast;
            currentBrightness = initBrightness;
            currentContrast = initContrast;
        }

        /// <summary>
        /// Получить изображение с фильтрами или без
        /// </summary>
        /// <param name="applyFilters">Применять фильтры да/нет</param>
        /// <returns>Изображение с фильтрами или без</returns>
        public Image<Bgr, byte> GetImage(bool applyFilters = false)
        {
            if (applyFilters)
            {
                var image = _originalImage.Copy();

                // Сначала применяем яркость и контраст
                FilterService.AdjustBrightness(image, currentBrightness);
                FilterService.AdjustContrast(image, currentContrast);

                // Затем все остальные фильтры
                foreach (var filter in _filters)
                {
                    filter(image);
                }
                return image;
            }
            return _originalImage.Copy();
        }

        /// <summary>
        /// Установить новое изображение
        /// </summary>
        /// <param name="image">Новое изображение</param>
        public void SetImage(Image<Bgr, byte> image)
        {
            _originalImage = image.Clone();
        }

        /// <summary>
        /// Очистить все фильтры
        /// </summary>
        public void ClearFilters()
        {
            _filters.Clear();
        }

        /// <summary>
        /// Получить список фильтров
        /// </summary>
        /// <returns>Список фильтров</returns>
        public List<Action<Image<Bgr, byte>>> GetFilters() => _filters;

        /// <summary>
        /// Настроить яркость
        /// </summary>
        /// <param name="newBrightness">Новая яркость</param>
        public void AdjustBrightness(int newBrightness)
        {
            currentBrightness = newBrightness;
            UpdateBrightnessAndContrastFilters();
        }

        /// <summary>
        /// Настроить контраст
        /// </summary>
        /// <param name="newContrast">Новый конраст</param>
        public void AdjustContrast(double newContrast)
        {
            currentContrast = newContrast;
            UpdateBrightnessAndContrastFilters();
        }

        /// <summary>
        /// Обновить фильтры яркости и контраста
        /// </summary>
        private void UpdateBrightnessAndContrastFilters()
        {
            // Очищаем старые фильтры, кроме цветовых
            _filters.RemoveAll(f => f.Method.Name == nameof(FilterService.AdjustBrightness) ||
                                    f.Method.Name == nameof(FilterService.AdjustContrast));
        }

        /// <summary>
        /// Применить медианный фильтр
        /// </summary>
        /// <param name="radius">Степень размытия (размер матрицы)</param>
        public void ApplyMedianBlur(int radius)
        {
            // Убираем старый фильтр
            _filters.Remove(_medianBlurFilter);

            // Обновляем фильтр или создаем новый
            _medianBlurFilter = image => FilterService.ApplyMedianBlur(_currentImage, _originalImage, radius);

            // Добавляем новый фильтр
            _filters.Add(_medianBlurFilter);
        }

        /// <summary>
        /// Применить медианный фильтр
        /// </summary>
        /// <param name="radius">Степень размытия (размер матрицы)</param>
        public void ApplyMask(Bitmap mask)
        {
            // Убираем старый фильтр
            _filters.Remove(_maskFilter);
            _maskBitmap = mask;

            // Обновляем фильтр или создаем новый
            _maskFilter = image => FilterService.ApplyMask(image, mask);

            // Добавляем новый фильтр
            _filters.Add(_maskFilter);
        }
    }
}
