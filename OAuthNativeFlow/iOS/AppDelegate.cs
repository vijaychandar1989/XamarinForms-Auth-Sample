using System;
using Foundation;
using UIKit;

namespace OAuthNativeFlow.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            global::Xamarin.Auth.WebViewConfiguration.IOS.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
           
            global::Xamarin.Forms.Forms.Init();
	    	global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);

        }

        public override bool OpenUrl
           (
               UIApplication application,
               NSUrl url,
               string sourceApplication,
               NSObject annotation
           )
        {
            // Convert iOS NSUrl to C#/netxf/BCL System.Uri - common API
            Uri uri_netfx = new Uri(url.AbsoluteString);

            // load redirect_url Page for parsing
            AuthenticationState.Authenticator.OnPageLoading(uri_netfx);

            return true;
        }
    }
}
