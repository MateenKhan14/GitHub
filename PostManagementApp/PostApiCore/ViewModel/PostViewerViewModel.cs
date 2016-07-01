using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostApiCore.Model;
using System.Windows.Input;
using System.Windows;

namespace PostApiCore.ViewModel
{
  public  class PostViewerViewModel: ModelBase
    {
        #region Variables
        private readonly Uri serviceURL;
        JsonLoaderService jsonLoaderService;
        private Post _selectedPost;
        private List<Post> postCollection;
        private string _copyContent;
        private string _postDetails;
        bool _isDataExtracted;
        private const string url = "http://jsonplaceholder.typicode.com/posts";
        #endregion
        #region Properties
        public List<Post> PostCollection
        {
            get
            {
                return postCollection;
            }

            set
            {
                postCollection = value;
                RaisePropertyChanged("PostCollection");
            }
        }

       
        public Post SelectedPost
        {
            get { return _selectedPost; }
            set
            {
                _selectedPost = value;
                PostDetails = string.Format("User ID = '{0}' and Post Id = '{1}' {2}Title = '{3}' {4}Body = '{5}'", _selectedPost.userId, _selectedPost.id, Environment.NewLine, _selectedPost.title, Environment.NewLine, _selectedPost.body);
                RaisePropertyChanged("SelectedPost");
            }
        }

       
        public string CopyContent
        {
            get { return _copyContent; }
            set
            {
                _copyContent = value;
                
                RaisePropertyChanged("CopyContent");
            }
        }

        
        public string PostDetails
        {
            get { return _postDetails; }
            set
            {
                _postDetails = value;
                RaisePropertyChanged("PostDetails");
            }
        }

      
        public bool IsDataExtracted
        {
            get { return _isDataExtracted; }
            set {
                _isDataExtracted = value;
                RaisePropertyChanged("IsDataExtracted");
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// when the view model is initialized all the data from Fake Rest Apli will be loaded in an Observable collection
        /// </summary>
        public PostViewerViewModel()
        {
            serviceURL = new Uri(url);
            postCollection = new List<Post>();
            jsonLoaderService = new JsonLoaderService(serviceURL);
            _isDataExtracted = false;
        }

        #endregion
        #region Commands

        private ICommand _loadPost;
        public ICommand LoadPostCommand
        {
            get
            {
                return _loadPost ?? (_loadPost = new Command(p => LoadData(), q => true));
            }
        }

        private ICommand _copyHTMLcommand;
        public ICommand CopyHTMLCommand
        {
            get
            {
                return _copyHTMLcommand ?? (_copyHTMLcommand = new Command(p => CopyHTML(), q => this.CanCopy()));
            }
        }

        private ICommand _copyJSONcommand;
        public ICommand CopyJSONCommand
        {
            get
            {
                return _copyJSONcommand ?? (_copyJSONcommand = new Command(p => CopyJSON(), q => this.CanCopy()));
            }
        }

        private ICommand _copyPlainTextcommand;
        public ICommand CopyPlainTextCommand
        {
            get
            {
                return _copyPlainTextcommand ?? (_copyPlainTextcommand = new Command(p => this.CopyPlainText(), q => this.CanCopy()));
            }
        }

        private ICommand _copyXMLcommand;
        public ICommand CopyJSONXMLCommand
        {
            get
            {
                return _copyXMLcommand ?? (_copyXMLcommand = new Command(p => this.CopyXML(), q => this.CanCopy()));
            }
        }

        #endregion
        #region Methods

       

        /// <summary>
        /// loads data from Json Service if no data pressent loads data from cache
        /// </summary>
        public async void LoadData()
        {
            IsDataExtracted = true;
            var result = await LoadDataAsync();
            if (result != null)
            {
                PostCollection = result;
                IsDataExtracted = false;
            }
            else
            {
                IsDataExtracted = false;
            }
        }

        /// <summary>
        /// Loads data Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<List<Post>> LoadDataAsync()
        {
            return await Task.Run(() => jsonLoaderService.LoadAPI());
        }


        /// <summary>
        /// Copies the Post into HTML
        /// </summary>
        private void CopyHTML()
        {
            string content = jsonLoaderService.ConvertObjectToHTML(SelectedPost);
            CopyContent = content;
            Clipboard.SetText(CopyContent);
        }

       


        /// <summary>
        /// Copies the Post into JSON
        /// </summary>
        private void CopyJSON()
        {
            string content = jsonLoaderService.ConvertObjectToJson(SelectedPost);
            CopyContent = content;
            Clipboard.SetText(CopyContent);
        }

       
       

        /// <summary>
        /// Copies the Post into Plain Text
        /// </summary>
        private void CopyPlainText()
        {
            CopyContent = string.Format("User ID = '{0}' and Post Id = '{1}' {2}Title = '{3}' {4}Body = '{5}'", _selectedPost.userId, _selectedPost.id, Environment.NewLine, _selectedPost.title, Environment.NewLine, _selectedPost.body); ;
            Clipboard.SetText(CopyContent);
        }

        

        /// <summary>
        /// Copies the Post into XML
        /// </summary>
        private void CopyXML()
        {
            
            string xmldata = jsonLoaderService.ConvertObjectToXML(SelectedPost);
            CopyContent = xmldata;
            Clipboard.SetText(CopyContent);
        }

        /// <summary>
        /// checks whether copy command can be executed
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanCopy()
        {
            return (SelectedPost != null);
        }

        #endregion
    }
}
