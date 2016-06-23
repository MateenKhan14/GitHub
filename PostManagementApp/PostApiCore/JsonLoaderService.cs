using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using PostApiCore.Model;
using System.Xml;
using System.Text;

namespace PostApiCore
{
    /// <summary>
    /// This class is used to get POST data from the fake Rest Api http://jsonplaceholder.typicode.com/ and then it uses Newtonsoft.Json to serialize data in user defined class
    /// I could have used JavaScriptSerializer,DataContractJsonSerializer but Newtonsoft is  50% faster than DataContractJsonSerializer, and 250% faster than JavaScriptSerializer
    /// so its the best Json Serializer 
    /// </summary>
    public class JsonLoaderService:IDisposable,iPostLoader
    {

        
            /// <summary>
            /// Represents the URL of JSON API
            /// </summary>
            private readonly Uri serviceURL;

            /// <summary>
            /// Represents the WebClient to Fetch the JSON API
            /// </summary>
            private WebClient restAPIClient;

        private List<ModelBase> lstdata;

            /// <summary>
            /// Construct the Instance of JSON API Loader
            /// </summary>
            /// <param name="apiURL"> The JSON API URL</param>
        public JsonLoaderService(Uri apiURL, List<ModelBase> data)
            {
                if (apiURL == null)
                {
                    throw new ArgumentNullException("apiURL", "Invalid URL of JSON Rest API");
                }

                this.serviceURL = apiURL;
                restAPIClient = new WebClient();
            lstdata = data;
            }

            /// <summary>
            /// Returns a full content of JSON API
            /// </summary>
            /// <returns>Content of JSON API</returns>
            public IEnumerable<ModelBase> LoadAPI()
            {
            IEnumerable<ModelBase> list;
            try
            {
                var content = this.restAPIClient.DownloadString(this.serviceURL);
                list = JsonConvert.DeserializeObject<List<Post>>(content);
                return list;
            }
            catch(Exception ex)
            {
                return null;   
            }
            }


        public string ConvertObjectToJson(Post data)
        {
            string retval = string.Empty;
            try
            {               
                retval = JsonConvert.SerializeObject(data);
            }
            catch(Exception)
            {
                return "Error while converting from post object post to JSON";
            }
            return retval;
        }

        public string ConvertObjectToXML(Post data)
        {
            string jsonData = string.Empty;
            XmlDocument doc;
            try
            {
                jsonData = JsonConvert.SerializeObject(data);
                 doc = JsonConvert.DeserializeXmlNode(jsonData,"Post");
                
            }
            catch (Exception)
            {
                return "Error while converting from JSON post to XML";
            }
            return doc.InnerXml;
        }

        public string ConvertObjectToHTML(Post data)
        {
            try
            {
                var xmlString = ConvertObjectToXML(data);
                StringBuilder html = new StringBuilder("<html><head></head><body>");
                html.Append(xmlString);
                html.Append("</body> </html>");
                return html.ToString();

            }
            catch (Exception)
            {
                return "Error while converting from JSON post to HTML";
            }

        }



        /// <summary>
        /// Returns the content of JSON API for specific element
        /// </summary>
        /// <param name="postid">Post Id that require to fetch the post content</param>
        /// <returns>Content of JSON API</returns>
        public ModelBase LoadSingleElementAPI(string postid)
            {
            ModelBase retObject = null;
            try
            {
                
                if (string.IsNullOrEmpty(postid))
                {
                    throw new ArgumentNullException("jsonContent", "Invalid Post Id");
                }

                string url = this.serviceURL + "/" + postid;
                var content = this.restAPIClient.DownloadString(url);
                 retObject = JsonConvert.DeserializeObject<ModelBase>(content);
            }
            catch(Exception ex)
            {

            }
            finally
            {

                

            }
            return retObject;
        }

            /// <summary>
            /// Disposes the objects
            /// </summary>
            public void Dispose()
            {
                this.restAPIClient = null;
            }
        }
}
