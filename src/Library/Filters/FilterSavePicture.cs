using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;
using System.Drawing;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterSavePicture : IFilter
    {
        private int imageCounter = 0;
        /// <summary>
        /// Recibe una imagen, la guarda en disco y la retorna
        /// </summary>
        /// <param name="image">Imagen que se quiere guardar.</param>
        /// <returns>Imagen recibida</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, $"picture{imageCounter}.jpg");
            imageCounter++;
            return image;
        }
    }
}
