
using System.ComponentModel;

namespace PostApiCore.Model
{
   public class Post: ModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the Data member userId of JSON API 
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// Represents the Data member Id of JSON API 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Represents the Data member Title of JSON API 
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Represents the Data member Body of JSON API 
        /// </summary>
        public string body { get; set; }

        
       
    }
}
