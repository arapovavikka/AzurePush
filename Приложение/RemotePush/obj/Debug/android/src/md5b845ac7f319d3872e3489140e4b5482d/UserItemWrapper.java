package md5b845ac7f319d3872e3489140e4b5482d;


public class UserItemWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RemotePush.UserItemWrapper, RemotePush, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", UserItemWrapper.class, __md_methods);
	}


	public UserItemWrapper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == UserItemWrapper.class)
			mono.android.TypeManager.Activate ("RemotePush.UserItemWrapper, RemotePush, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
