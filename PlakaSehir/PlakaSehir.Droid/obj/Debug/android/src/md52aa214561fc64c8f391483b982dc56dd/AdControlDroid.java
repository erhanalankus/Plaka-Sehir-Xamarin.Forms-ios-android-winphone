package md52aa214561fc64c8f391483b982dc56dd;


public class AdControlDroid
	extends md5d4dd78677dce656d5db26c85a3743ef3.ViewRenderer
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PlakaSehir.Droid.AdControlDroid, PlakaSehir.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdControlDroid.class, __md_methods);
	}


	public AdControlDroid (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == AdControlDroid.class)
			mono.android.TypeManager.Activate ("PlakaSehir.Droid.AdControlDroid, PlakaSehir.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AdControlDroid (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == AdControlDroid.class)
			mono.android.TypeManager.Activate ("PlakaSehir.Droid.AdControlDroid, PlakaSehir.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public AdControlDroid (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == AdControlDroid.class)
			mono.android.TypeManager.Activate ("PlakaSehir.Droid.AdControlDroid, PlakaSehir.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
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
