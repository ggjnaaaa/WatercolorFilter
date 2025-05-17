using Emgu.CV.Structure;
using Emgu.CV;
using System.Collections;
using System.Resources;
using System.ComponentModel;
using System.Globalization;

namespace KR.Services
{
    /// <summary>
    /// Сервис для загрузки изображений.
    /// </summary>
    public static class ImageLoader
    {
        /// <summary>
        /// Загружает изображение с помощью диалогового окна.
        /// </summary>
        /// <returns>Загруженное изображение в формате BGR, или null, если изображение не выбрано.</returns>
        public static Image<Bgr, byte> LoadImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.jpg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new Image<Bgr, byte>(openFileDialog.FileName);
                }
            }
            return null;
        }

        public static List<Bitmap> LoadMaskBitmapsFromFormResources()
        {
            var list = new List<Bitmap>();
            var resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            int i = 1;
            while (true)
            {
                string maskName = $"Mask_{i}";
                object obj = resourceSet.Cast<DictionaryEntry>()
                                        .FirstOrDefault(e => e.Key.ToString() == maskName)
                                        .Value;
                if (obj is byte[] bytes)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        Bitmap bmp = new Bitmap(ms);
                        list.Add(bmp);

                        i++;
                    }
                }
                else
                {
                    break;
                }
            }

            return list;
        }
    }
}
