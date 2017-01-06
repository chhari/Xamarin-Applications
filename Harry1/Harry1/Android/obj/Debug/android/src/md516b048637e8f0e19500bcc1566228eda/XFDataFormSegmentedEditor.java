package md516b048637e8f0e19500bcc1566228eda;


public class XFDataFormSegmentedEditor
	extends com.telerik.widget.dataform.visualization.editors.DataFormSegmentedEditor
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_createButton:(Landroid/content/Context;)Landroid/widget/RadioButton;:GetCreateButton_Landroid_content_Context_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.InputRenderer.Android.DataForm.XFDataFormSegmentedEditor, Telerik.XamarinForms.InputRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", XFDataFormSegmentedEditor.class, __md_methods);
	}


	public XFDataFormSegmentedEditor (com.telerik.widget.dataform.visualization.RadDataForm p0, com.telerik.widget.dataform.engine.EntityProperty p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == XFDataFormSegmentedEditor.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.DataForm.XFDataFormSegmentedEditor, Telerik.XamarinForms.InputRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", "Com.Telerik.Widget.Dataform.Visualization.RadDataForm, Telerik.Xamarin.Android.Input, Version=2016.3.1220.0, Culture=neutral, PublicKeyToken=null:Com.Telerik.Widget.Dataform.Engine.IEntityProperty, Telerik.Xamarin.Android.Input, Version=2016.3.1220.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public android.widget.RadioButton createButton (android.content.Context p0)
	{
		return n_createButton (p0);
	}

	private native android.widget.RadioButton n_createButton (android.content.Context p0);

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
