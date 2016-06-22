using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostApiCore.Model;
using System.Windows.Input;
using System.Windows;

namespace PostApiCore.ViewModel
{
  public  class PostViewerViewModel: ModelBase
    {
        private readonly Uri serviceURL;
        JsonLoaderService jsonLoaderService;

        private IEnumerable<ModelBase> postCollection;

        public IEnumerable<ModelBase> PostCollection
        {
            get
            {
                return postCollection;
            }

            set
            {
                postCollection = value;
            }
        }

        private Post _selectedPost;
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

        private string _copyContent;
        public string CopyContent
        {
            get { return _copyContent; }
            set
            {
                _copyContent = value;
                
                RaisePropertyChanged("CopyContent");
            }
        }

        private string _postDetails;
        public string PostDetails
        {
            get { return _postDetails; }
            set
            {
                _postDetails = value;
                RaisePropertyChanged("PostDetails");
            }
        }

        bool _isDataExtracted;
        public bool IsDataExtracted
        {
            get { return _isDataExtracted; }
            set {
                _isDataExtracted = value;
            }
        }
        
        /// <summary>
        /// when the view model is initialized all the data from Fake Rest Apli will be loaded in an Observable collection
        /// </summary>
        public PostViewerViewModel()
        {
            serviceURL = new Uri("http://jsonplaceholder.typicode.com/posts");
            PostCollection = new ObservableCollection<Post>();
            jsonLoaderService = new JsonLoaderService(serviceURL, PostCollection.ToList());
            var result = jsonLoaderService.LoadAPI();
            if (result != null)
            {
                PostCollection = result;
                IsDataExtracted = false;
            }
            else
            {
                IsDataExtracted = true;
            }
        }


        #region Commands

        private ICommand _copyJSONcommand;
        public ICommand CopyJSONCommand
        {
            get
            {
                return _copyJSONcommand ?? (_copyJSONcommand = new Command(p => CopyJSON(), q => this.CanCopyJSON()));
            }
        }

        private ICommand _copyPlainTextcommand;
        public ICommand CopyPlainTextCommand
        {
            get
            {
                return _copyPlainTextcommand ?? (_copyPlainTextcommand = new Command(p => this.CopyPlainText(), q => this.CanCopyPlainText()));
            }
        }

        private ICommand _copyXMLcommand;
        public ICommand CopyJSONXMLCommand
        {
            get
            {
                return _copyXMLcommand ?? (_copyXMLcommand = new Command(p => this.CopyXML(), q => this.CanCopyXML()));
            }
        }

        #endregion


        #region methods
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
        /// Is Copy JSON
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanCopyJSON()
        {
            return (SelectedPost != null);
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
        /// Is Copy Plain Text
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanCopyPlainText()
        {
            return (SelectedPost != null);
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
        /// Is Copy XML
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanCopyXML()
        {
            return (SelectedPost != null);
        }

        #endregion
    }
}
