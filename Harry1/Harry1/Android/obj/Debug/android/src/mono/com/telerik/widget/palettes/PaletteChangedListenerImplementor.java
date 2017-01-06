package mono.com.telerik.widget.palettes;


public class PaletteChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.widget.palettes.PaletteChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPaletteUpdated:(Lcom/telerik/widget/palettes/ChartPalette;)V:GetOnPaletteUpdated_Lcom_telerik_widget_palettes_ChartPalette_Handler:Com.Telerik.Widget.Palettes.IPaletteChangedListenerInvoker, Telerik.Xamarin.Android.Chart\n" +
			"";
		mono.android.Runtime.register ("Com.Telerik.Widget.Palettes.IPaletteChangedListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2016.3.1220.0, Culture=neutral, PublicKeyToken=null", PaletteChangedListenerImplementor.class, __md_methods);
	}


	public PaletteChangedListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PaletteChangedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Telerik.Widget.Palettes.IPaletteChangedListenerImplementor, Telerik.Xamarin.Android.Chart, Version=2016.3.1220.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPaletteUpdated (com.telerik.widget.palettes.ChartPalette p0)
	{
		n_onPaletteUpdated (p0);
	}

	private native void n_onPaletteUpdated (com.telerik.widget.palettes.ChartPalette p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
