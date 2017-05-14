package md5b845ac7f319d3872e3489140e4b5482d;


public class ToDoActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_AskServer:(Landroid/view/View;)V:__export__\n" +
			"n_AddItem:(Landroid/view/View;)V:__export__\n" +
			"n_AddUser:(Landroid/view/View;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("RemotePush.ToDoActivity, RemotePush, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ToDoActivity.class, __md_methods);
	}


	public ToDoActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToDoActivity.class)
			mono.android.TypeManager.Activate ("RemotePush.ToDoActivity, RemotePush, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public void AskServer (android.view.View p0)
	{
		n_AskServer (p0);
	}

	private native void n_AskServer (android.view.View p0);


	public void AddItem (android.view.View p0)
	{
		n_AddItem (p0);
	}

	private native void n_AddItem (android.view.View p0);


	public void AddUser (android.view.View p0)
	{
		n_AddUser (p0);
	}

	private native void n_AddUser (android.view.View p0);

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
