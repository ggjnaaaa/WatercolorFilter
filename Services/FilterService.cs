using Emgu.CV.Structure;
using Emgu.CV;

namespace KR.Services
{
    public static class FilterService
    {
        /// <summary>
        /// Применяет медианный фильтр.
        /// </summary>
        public static void ApplyMedianBlur(Image<Bgr, byte> source, Image<Bgr, byte> destination, int kernelSize)
        {
            if (source == null || destination == null) return;

            kernelSize = Math.Max(1, kernelSize);
            if (kernelSize % 2 == 0) kernelSize++;

            CvInvoke.MedianBlur(source, destination, kernelSize);
        }

        /// <summary>
        /// Регулирует яркость изображения.
        /// </summary>
        public static void AdjustBrightness(Image<Bgr, byte> image, int brightness)
        {
            if (image == null) return;

            var brightnessMatrix = new Image<Bgr, byte>(image.Size);
            brightnessMatrix.SetValue(new Bgr(brightness, brightness, brightness));
            CvInvoke.Add(image, brightnessMatrix, image);
            brightnessMatrix.Dispose();
        }

        /// <summary>
        /// Регулирует контраст изображения.
        /// </summary>
        public static void AdjustContrast(Image<Bgr, byte> image, double contrast)
        {
            if (image == null) return;

            image._Mul(contrast);
        }

        /// <summary>
        /// Накладывает маску на изображение (логическое сложение)
        /// </summary>
        /// <param name="image">Изображение, к которому применяем маску (обновляется)</param>
        /// <param name="maskBitmap">Маска в виде Bitmap (RGB)</param>
        public static void ApplyMask(Image<Bgr, byte> image, Bitmap mask, float alpha = 0.4f)
        {
            if (image == null || mask == null) return;

            using (var originalMask = mask.ToImage<Bgr, byte>())
            using (var resizedMask = originalMask.Resize(image.Width, image.Height, Emgu.CV.CvEnum.Inter.Linear))
            using (var blurredMask = resizedMask.SmoothGaussian(15))
            {
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var srcColor = image[y, x];
                        var maskColor = blurredMask[y, x];

                        if (maskColor.Blue > 250 && maskColor.Green > 250 && maskColor.Red > 250)
                            continue;

                        byte b = (byte)(srcColor.Blue * (1 - alpha) + maskColor.Blue * alpha);
                        byte g = (byte)(srcColor.Green * (1 - alpha) + maskColor.Green * alpha);
                        byte r = (byte)(srcColor.Red * (1 - alpha) + maskColor.Red * alpha);

                        image[y, x] = new Bgr(b, g, r);
                    }
                }
            }
        }
    }
}
