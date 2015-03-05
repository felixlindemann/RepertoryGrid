using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RepertoryGrid.BaseClasses;
using System.Drawing;
using System.Diagnostics;

namespace RepertoryGrid.classes
{
    public class ImageFile : NotifyPropertyChanged
    {

        #region variables

        private Guid id = Guid.NewGuid();
        private Interview parentInterview;
        private FileInfo fi;
        private Image image;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            get { return id; }
            set { SetPropertyField("Id", ref id, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Interview ParentInterview
        {
            get { return parentInterview; }
            set { SetPropertyField("ParentInterview", ref parentInterview, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public FileInfo Path
        {
            get { return fi; }
            set
            {
                SetPropertyField("Path", ref fi, value);
                Load();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Image ImageBitmap
        {
            get { return image; }
        }

        #endregion

        #region Constructor

        public ImageFile(Interview interview, DirectoryInfo dir)
        {
            if (!dir.Exists) dir.Create();

            fi = new FileInfo(System.IO.Path.Combine(dir.FullName, this.id.ToString() + ".png"));
            interview.Images.Add(this);

        }

        #endregion

        #region Methods

        public void Load()
        {
            if (this.Path != null && fi.Exists)
            {
                image = Bitmap.FromFile(Path.FullName);
                this.FirePropertyChanged("Image");
            }


        }

        #endregion

    }
}
