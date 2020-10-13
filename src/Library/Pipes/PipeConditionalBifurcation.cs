using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeConditionalBifurcation : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;
        
        private PictureValidator pictureValidator;

        /// <summary>
        /// La cañería recibe una imagen, y envía por una cañería dependiendo de si la imagen contiene una cara o no.
        /// </summary>
        /// <param name="nextPipe">Siguiente cañeria si contiene una cara</param>
        /// <param name="next2Pipe">Siguiente cañeria si no contiene una cara</param>
        public PipeConditionalBifurcation(IPipe nextPipe, IPipe next2Pipe) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;           
            this.pictureValidator = new PictureValidator();
        }
        
        /// <summary>
        /// La cañería recibe una imagen, si esta contiene una cara, 
        /// la original por una cañería y sino por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            if(this.pictureValidator.ValidatePictureContainFace(picture.Path))
            {
                return this.nextPipe.Send(picture);
            }
            else 
            {
                return this.next2Pipe.Send(picture);
            }   
        }
    }
}
