package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "Harry1.Android.dll" comes first in this list. */
		"Harry1.Android.dll",
		"FormsViewGroup.dll",
		"Microsoft.WindowsAzure.Mobile.dll",
		"Microsoft.WindowsAzure.Mobile.Ext.dll",
		"Microsoft.WindowsAzure.Mobile.SQLiteStore.dll",
		"Newtonsoft.Json.dll",
		"Plugin.CurrentActivity.dll",
		"Plugin.Geolocator.Abstractions.dll",
		"Plugin.Geolocator.dll",
		"Plugin.Permissions.Abstractions.dll",
		"Plugin.Permissions.dll",
		"SQLitePCL.dll",
		"SQLitePCL.Ext.dll",
		"SQLitePCLRaw.batteries_green.dll",
		"SQLitePCLRaw.core.dll",
		"SQLitePCLRaw.lib.e_sqlite3.dll",
		"SQLitePCLRaw.provider.e_sqlite3.dll",
		"System.Net.Http.Extensions.dll",
		"System.Net.Http.Primitives.dll",
		"Telerik.Xamarin.Android.Chart.dll",
		"Telerik.Xamarin.Android.Common.dll",
		"Telerik.Xamarin.Android.Data.dll",
		"Telerik.Xamarin.Android.Input.dll",
		"Telerik.Xamarin.Android.List.dll",
		"Telerik.Xamarin.Android.Primitives.dll",
		"Telerik.XamarinForms.Chart.dll",
		"Telerik.XamarinForms.ChartRenderer.Android.dll",
		"Telerik.XamarinForms.Common.Android.dll",
		"Telerik.XamarinForms.Common.dll",
		"Telerik.XamarinForms.DataControls.dll",
		"Telerik.XamarinForms.DataControlsRenderer.Android.dll",
		"Telerik.XamarinForms.Input.dll",
		"Telerik.XamarinForms.InputRenderer.Android.dll",
		"Telerik.XamarinForms.Primitives.dll",
		"Telerik.XamarinForms.PrimitivesRenderer.Android.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.v8.RenderScript.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Maps.Android.dll",
		"Xamarin.Forms.Maps.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Xamarin.GooglePlayServices.Base.dll",
		"Xamarin.GooglePlayServices.Basement.dll",
		"Xamarin.GooglePlayServices.Maps.dll",
		"Harry1.Portable.dll",
		"System.Runtime.dll",
		"System.Resources.ResourceManager.dll",
		"System.Threading.Tasks.dll",
		"System.ObjectModel.dll",
		"System.Diagnostics.Debug.dll",
		"System.Reflection.dll",
		"System.Text.RegularExpressions.dll",
		"System.Net.Primitives.dll",
		"System.Linq.Expressions.dll",
		"System.Collections.dll",
		"System.Diagnostics.Tools.dll",
		"System.Globalization.dll",
		"System.Threading.dll",
		"System.Runtime.Serialization.Primitives.dll",
		"System.Linq.dll",
		"System.Reflection.Extensions.dll",
		"System.Text.Encoding.dll",
		"System.Runtime.Extensions.dll",
		"System.Linq.Queryable.dll",
		"System.IO.dll",
		"System.Xml.XDocument.dll",
		"System.Dynamic.Runtime.dll",
		"System.Xml.ReaderWriter.dll",
		"System.Text.Encoding.Extensions.dll",
		"System.Runtime.InteropServices.dll",
		"System.ComponentModel.dll",
		"System.Collections.Concurrent.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_23";
}
