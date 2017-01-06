package md5cb8153729b574db9512755935d84a15f;


public class AndroidChartPanAndZoomBehavior
	extends com.telerik.widget.chart.visualization.behaviors.ChartPanAndZoomBehavior
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setZoomToChart:(DDDD)V:GetSetZoomToChart_DDDDHandler\n" +
			"n_setPanOffsetToChart:(DD)V:GetSetPanOffsetToChart_DDHandler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.AndroidChartPanAndZoomBehavior, Telerik.XamarinForms.ChartRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", AndroidChartPanAndZoomBehavior.class, __md_methods);
	}


	public AndroidChartPanAndZoomBehavior () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AndroidChartPanAndZoomBehavior.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.AndroidChartPanAndZoomBehavior, Telerik.XamarinForms.ChartRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void setZoomToChart (double p0, double p1, double p2, double p3)
	{
		n_setZoomToChart (p0, p1, p2, p3);
	}

	private native void n_setZoomToChart (double p0, double p1, double p2, double p3);


	public void setPanOffsetToChart (double p0, double p1)
	{
		n_setPanOffsetToChart (p0, p1);
	}

	private native void n_setPanOffsetToChart (double p0, double p1);

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
