﻿namespace Facebook
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents the Facebook Context class.
    /// </summary>
    public class FacebookContext
    {
        /// <summary>
        /// Current Facebook application.
        /// </summary>
        private static FacebookContext instance = new FacebookContext();

        /// <summary>
        /// Gets the current Facebook application.
        /// </summary>
        public static IFacebookApplication Current
        {
            get { return instance.InnerCurrent; }
        }

        /// <summary>
        /// Set the current facebook application.
        /// </summary>
        /// <param name="facebookApplication">
        /// The facebook application.
        /// </param>
        public static void SetApplication(IFacebookApplication facebookApplication)
        {
            Contract.Requires(facebookApplication != null);
            instance.InnerSetApplication(facebookApplication);
        }

        /// <summary>
        /// Set the current facebook application.
        /// </summary>
        /// <param name="getFacebookApplication">
        /// The get facebook application.
        /// </param>
        public static void SetApplication(Func<IFacebookApplication> getFacebookApplication)
        {
            Contract.Requires(getFacebookApplication != null);

            instance.InnerSetApplication(getFacebookApplication);
        }

#if !SILVERLIGHT
        private IFacebookApplication current = FacebookConfigurationSection.Current;
#else
        private IFacebookApplication current = new NullFacebookApplication();
#endif
        public IFacebookApplication InnerCurrent
        {
            get { return this.current ?? new NullFacebookApplication(); }
        }

        public void InnerSetApplication(IFacebookApplication facebookApplication)
        {
            Contract.Requires(facebookApplication != null);

            this.current = facebookApplication;
        }

        public void InnerSetApplication(Func<IFacebookApplication> getFacebookApplication)
        {
            Contract.Requires(getFacebookApplication != null);

            this.current = getFacebookApplication();
        }

        /// <summary>
        /// Represents a null Facebook application.
        /// </summary>
        private class NullFacebookApplication : IFacebookApplication
        {
            /// <summary>
            /// Gets the application id.
            /// </summary>
            public string AppId
            {
                get { return null; }
            }

            /// <summary>
            /// Gets the application secret.
            /// </summary>
            public string AppSecret
            {
                get { return null; }
            }

            /// <summary>
            /// Gets the site url.
            /// </summary>
            public string SiteUrl
            {
                get { return null; }
            }

            /// <summary>
            /// Gets the canvas page.
            /// </summary>
            public string CanvasPage
            {
                get { return null; }
            }

            /// <summary>
            /// Gets the canvas url.
            /// </summary>
            public string CanvasUrl
            {
                get { return null; }
            }

            /// <summary>
            /// Gets the url to return the user after they cancel authorization.
            /// </summary>
            public string CancelUrlPath
            {
                get { return null; }
            }
        }
    }
}
