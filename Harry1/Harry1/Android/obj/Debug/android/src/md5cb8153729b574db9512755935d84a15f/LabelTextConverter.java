package md5cb8153729b574db9512755935d84a15f;


public class LabelTextConverter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.android.common.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_apply:(Ljava/lang/Object;)Ljava/lang/Object;:GetApply_Ljava_lang_Object_Handler:Com.Telerik.Android.Common.IFunctionInvoker, Telerik.Xamarin.Android.Common\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.LabelTextConverter, Telerik.XamarinForms.ChartRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", LabelTextConverter.class, __md_methods);
	}


	public LabelTextConverter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LabelTextConverter.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.LabelTextConverter, Telerik.XamarinForms.ChartRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object apply (java.lang.Object p0)
	{
		return n_apply (p0);
	}

	private native java.lang.Object n_apply (java.lang.Object p0);

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