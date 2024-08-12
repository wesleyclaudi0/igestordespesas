package com.artech.igestorappdespesas.appdespesas;

import com.genexus.android.core.providers.EntityDataProvider;

public class AppEntityDataProvider extends EntityDataProvider
{
	public AppEntityDataProvider()
	{
		EntityDataProvider.AUTHORITY = "com.artech.igestorappdespesas.appdespesas.appentityprovider";
		EntityDataProvider.URI_MATCHER = buildUriMatcher();
	}
}
