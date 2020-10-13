using System;
using TwitterUCU;

namespace CompAndDel
{
    /// <summary>
    /// Clase encargada de brindar las operaciones necesarias para publicar pasajeros y conductores en Twitter
    /// </summary>
    public class TwitterPublisher: IPublisher
    {
        private const string ConsumerKey = "CkovShLMNVCY0STsZlcRUFu99";
        private const string ConsumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
        private const string AccessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
        private const string AccessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
        private TwitterImage twitter;
        private PictureValidator pictureValidator;

        public TwitterPublisher()
        {
            this.twitter = new TwitterImage(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);
        }
        public void PublishPicture (String picture)
        {
            Console.WriteLine(twitter.PublishToTwitter("",picture));
        }    
    }
}