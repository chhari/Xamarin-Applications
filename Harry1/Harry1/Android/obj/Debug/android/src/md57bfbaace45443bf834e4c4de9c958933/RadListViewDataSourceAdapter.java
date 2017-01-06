package md57bfbaace45443bf834e4c4de9c958933;


public class RadListViewDataSourceAdapter
	extends com.telerik.widget.list.ListViewDataSourceAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateItemViewHolder:(Landroid/view/ViewGroup;I)Lcom/telerik/widget/list/ListViewHolder;:GetOnCreateItemViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"n_onCreateSwipeContentHolder:(Landroid/view/ViewGroup;)Lcom/telerik/widget/list/ListViewHolder;:GetOnCreateSwipeContentHolder_Landroid_view_ViewGroup_Handler\n" +
			"n_onCreateGroupViewHolder:(Landroid/view/ViewGroup;I)Lcom/telerik/widget/list/ListViewHolder;:GetOnCreateGroupViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"n_onBindGroupViewHolder:(Lcom/telerik/widget/list/ListViewHolder;Ljava/lang/Object;)V:GetOnBindGroupViewHolder_Lcom_telerik_widget_list_ListViewHolder_Ljava_lang_Object_Handler\n" +
			"n_onBindItemViewHolder:(Lcom/telerik/widget/list/ListViewHolder;Ljava/lang/Object;)V:GetOnBindItemViewHolder_Lcom_telerik_widget_list_ListViewHolder_Ljava_lang_Object_Handler\n" +
			"n_onBindSwipeContentHolder:(Lcom/telerik/widget/list/ListViewHolder;I)V:GetOnBindSwipeContentHolder_Lcom_telerik_widget_list_ListViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.DataControlsRenderer.Android.RadListViewDataSourceAdapter, Telerik.XamarinForms.DataControlsRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", RadListViewDataSourceAdapter.class, __md_methods);
	}


	public RadListViewDataSourceAdapter (java.util.List p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == RadListViewDataSourceAdapter.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.DataControlsRenderer.Android.RadListViewDataSourceAdapter, Telerik.XamarinForms.DataControlsRenderer.Android, Version=2017.1.1220.233, Culture=neutral, PublicKeyToken=null", "System.Collections.IList, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public com.telerik.widget.list.ListViewHolder onCreateItemViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateItemViewHolder (p0, p1);
	}

	private native com.telerik.widget.list.ListViewHolder n_onCreateItemViewHolder (android.view.ViewGroup p0, int p1);


	public com.telerik.widget.list.ListViewHolder onCreateSwipeContentHolder (android.view.ViewGroup p0)
	{
		return n_onCreateSwipeContentHolder (p0);
	}

	private native com.telerik.widget.list.ListViewHolder n_onCreateSwipeContentHolder (android.view.ViewGroup p0);


	public com.telerik.widget.list.ListViewHolder onCreateGroupViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateGroupViewHolder (p0, p1);
	}

	private native com.telerik.widget.list.ListViewHolder n_onCreateGroupViewHolder (android.view.ViewGroup p0, int p1);


	public void onBindGroupViewHolder (com.telerik.widget.list.ListViewHolder p0, java.lang.Object p1)
	{
		n_onBindGroupViewHolder (p0, p1);
	}

	private native void n_onBindGroupViewHolder (com.telerik.widget.list.ListViewHolder p0, java.lang.Object p1);


	public void onBindItemViewHolder (com.telerik.widget.list.ListViewHolder p0, java.lang.Object p1)
	{
		n_onBindItemViewHolder (p0, p1);
	}

	private native void n_onBindItemViewHolder (com.telerik.widget.list.ListViewHolder p0, java.lang.Object p1);


	public void onBindSwipeContentHolder (com.telerik.widget.list.ListViewHolder p0, int p1)
	{
		n_onBindSwipeContentHolder (p0, p1);
	}

	private native void n_onBindSwipeContentHolder (com.telerik.widget.list.ListViewHolder p0, int p1);

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
